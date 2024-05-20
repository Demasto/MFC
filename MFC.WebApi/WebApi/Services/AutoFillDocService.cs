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
        var tempFilePath = StaticDirectory.CopyFile(pathToCertificate, autoName);
        
        new AutoFillDocService(tempFilePath).ReplaceALl(current);

    }
    

    public void ReplaceALl(AppUser current)
    {
        var appUserDto = current.ToDTO();


        
        ReplaceValue("<имя>", appUserDto.Name.First);
        ReplaceValue("<фамилия>", appUserDto.Name.Second);
        ReplaceValue("<отчество>", appUserDto.Name.Middle);
        
        var parentCaseName = appUserDto.Name.ToParent();
        
        ReplaceValue("<имя-р>", parentCaseName.First);
        ReplaceValue("<фамилия-р>", parentCaseName.Second);
        ReplaceValue("<отчество-р>", parentCaseName.Middle);
        
        ReplaceValue("<инн>", appUserDto.INN);
        ReplaceValue("<телефон>", appUserDto.PhoneNumber);
        
        switch (current.UserRole)
        {
            case Role.Student:
            {
                var studentDTO = appUserDto as StudentDTO;
                ReplaceValue("<группа>", studentDTO.Group);
                ReplaceValue("<направление>", studentDTO.DirectionOfStudy);
                ReplaceValue("<номер>", studentDTO.ServiceNumber);
                break;
            }
            case Role.Employee:
            {
                var employeeDTO = appUserDto as EmployeeDTO;
                ReplaceValue("<должность>", employeeDTO.Post);
                ReplaceValue("<институт>", employeeDTO.Institute);
                break;
            }
        }
            
        CloseDocument();
    }
    

    private void ReplaceValue(string tag, string value)
    {
        var find = _application.Selection.Find;

        
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
    
    public void CloseDocument()
    {
        _application.ActiveDocument.Save();
        _application.ActiveDocument.Close();
        _application.Quit(); 
    }
}