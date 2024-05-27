using System.Text.Json;
using Domain.DTO.Users;
using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Services;

using Microsoft.Office.Interop.Word;

public class AutoFillDocService
{
    private readonly Application _application;
    
    public AutoFillDocService(string path)
    {
        _application = new Application();

        Object filePath = path;
        
        _application.Documents.Open(ref filePath);
    }

    public static void Generate(AppUser current, string fileNameWithExtension, string autoName)
    {
        
        var pathToCertificate = SaveDirectory.PathToFile(ServiceType.Certificate, fileNameWithExtension);

        // Копирование файла в wwwroot
        var tempFilePath = StaticDirectory.CopyFile(pathToCertificate, autoName, Dir.Auto);
        
        new AutoFillDocService(tempFilePath).ReplaceALl(current);
    }
    public static void GenerateTemplate(string fileName, string path)
    {
        // Копирование файла в wwwroot
        var tempFilePath = StaticDirectory.CopyFile(path, fileName, Dir.Template);
        
        new AutoFillDocService(tempFilePath).ExtractTemplate();
    }
    

    private void ReplaceALl(AppUser current)
    {
        var appUserDto = current.ToDTO();

        
        ReplaceValue(UserTags.FirstName, appUserDto.Name.First);
        ReplaceValue(UserTags.SecondName, appUserDto.Name.Second);
        ReplaceValue(UserTags.MiddleName, appUserDto.Name.Middle);
        
        var parentCaseName = appUserDto.Name.ToParent();
        
        ReplaceValue(UserTags.FirstNameParent, parentCaseName.First);
        ReplaceValue(UserTags.SecondNameParent, parentCaseName.Second);
        ReplaceValue(UserTags.MiddleNameParent, parentCaseName.Middle);
        
        ReplaceValue(UserTags.INN, appUserDto.INN);
        ReplaceValue(UserTags.PhoneNumber, appUserDto.PhoneNumber);
        
        switch (current.UserRole)
        {
            case Role.Student:
            {
                var studentDTO = appUserDto as StudentDTO;
                ReplaceValue(UserTags.Group, studentDTO!.Group);
                ReplaceValue(UserTags.DirectionOfStudy, studentDTO.DirectionOfStudy);
                ReplaceValue(UserTags.ServiceNumber, studentDTO.ServiceNumber);
                break;
            }
            case Role.Employee:
            {
                var employeeDTO = appUserDto as EmployeeDTO;
                ReplaceValue(UserTags.Post, employeeDTO!.Post);
                ReplaceValue(UserTags.Institute, employeeDTO.Institute);
                break;
            }
        }
            
        CloseDocument();
    }

    private void ExtractTemplate()
    {

        ReplaceValue(UserTags.FirstName);
        ReplaceValue(UserTags.SecondName);
        ReplaceValue(UserTags.MiddleName);
        
        ReplaceValue(UserTags.FirstNameParent);
        ReplaceValue(UserTags.SecondNameParent);
        ReplaceValue(UserTags.MiddleNameParent);
        
        ReplaceValue(UserTags.INN);
        ReplaceValue(UserTags.PhoneNumber);
        
        ReplaceValue(UserTags.Group);
        ReplaceValue(UserTags.DirectionOfStudy);
        ReplaceValue(UserTags.ServiceNumber);
        
        ReplaceValue(UserTags.Post);
        ReplaceValue(UserTags.Institute);
        CloseDocument();
    }


    private void ReplaceValue(string tag, string? value = null)
    {
        var find = _application.Selection.Find;
        
        value ??= string.Empty;
        
        find.Text = tag;
        find.Replacement.Text = value;
        

        find.Execute(
            FindText: Type.Missing,
            MatchCase: false,
            MatchWholeWord: false,
            MatchWildcards: false,
            MatchSoundsLike: Type.Missing,
            MatchAllWordForms: false,
            Forward: true,
            Wrap: WdFindWrap.wdFindContinue,
            Format: false,
            ReplaceWith: Type.Missing, 
            Replace: WdReplace.wdReplaceOne);
    }
    
    private void CloseDocument()
    {
        _application.ActiveDocument.Save();
        _application.ActiveDocument.Close();
        _application.Quit(); 
    }
}

public static class UserTags
{
    public const string FirstName = "<имя>";
    public const string SecondName = "<фамилия>";
    public const string MiddleName = "<отчество>";
    
    public const string FirstNameParent = "<имя-р>";
    public const string SecondNameParent = "<фамилия-р>";
    public const string MiddleNameParent = "<отчество-р>";
    
    public const string INN = "<инн>";
    public const string PhoneNumber = "<телефон>";
    
    public const string Group = "<инн>";
    public const string DirectionOfStudy = "<телефон>";
    public const string ServiceNumber = "<номер>";
    
    public const string Post = "<должность>";
    public const string Institute = "<институт>";
}