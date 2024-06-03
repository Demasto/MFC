using Domain.DTO.Users;
using Domain.Entities;
using Domain.Entities.Users;

using WebApi.Filters;

namespace WebApi.Services;

using Microsoft.Office.Interop.Word;

public class AutoFillDocService
{
    private readonly Application _application;
    
    private AutoFillDocService(string path)
    {
        _application = new Application();

        Object filePath = path;
        
        _application.Documents.Open(ref filePath);
    }

    public static void Generate(AppUser current, string fileNameWithExtension, string autoName, ServiceType type)
    {
        
        var pathToCertificate = SaveDirectory.PathToFile(type, fileNameWithExtension);

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
        
        ReplaceValue(UserTags.FullName, $"{appUserDto.Name.Second} {appUserDto.Name.First} {appUserDto.Name.Middle}");
        
        var parentCaseName = appUserDto.Name.ToParent();
        
        ReplaceValue(UserTags.FirstNameParent, parentCaseName.First);
        ReplaceValue(UserTags.SecondNameParent, parentCaseName.Second);
        ReplaceValue(UserTags.MiddleNameParent, parentCaseName.Middle);
        
        ReplaceValue(UserTags.FullNameParent, $"{parentCaseName.Second} {parentCaseName.First} {parentCaseName.Middle}");
        
        ReplaceValue(UserTags.DateOfBrith, appUserDto.Passport.DateOfBrith.ToString());
        
        ReplaceValue(UserTags.INN, appUserDto.INN);
        ReplaceValue(UserTags.PhoneNumber, appUserDto.PhoneNumber);
        
        switch (current.UserRole)
        {
            case Role.Student:
            {
                var studentDTO = appUserDto as StudentDTO;
                ReplaceValue(StudentTags.Group, studentDTO?.Group);
                ReplaceValue(StudentTags.Course, studentDTO?.Course().ToString());
                ReplaceValue(StudentTags.DirectionOfStudy, studentDTO?.DirectionOfStudy);
                ReplaceValue(StudentTags.ServiceNumber, studentDTO?.ServiceNumber);
                // TODO дата окончания института
                // TODO КОД И НАИМЕНОВАНИЕ СПЕЦИАЛЬНОСТИ / НАПРАВЛЕНИЯ ПОДГОТОВКИ
                break;
            }
            case Role.Employee:
            {
                var employeeDTO = appUserDto as EmployeeDTO;
                ReplaceValue(EmployeeTags.Post, employeeDTO?.Post);
                ReplaceValue(EmployeeTags.Institute, employeeDTO?.Institute);
                break;
            }
        }
            
        CloseDocument();
    }

    private void ExtractTemplate()
    {
        ReplaceValue(UserTags.FullName);
        ReplaceValue(UserTags.FullNameParent);
        
        ReplaceValue(UserTags.FirstName);
        ReplaceValue(UserTags.SecondName);
        ReplaceValue(UserTags.MiddleName);
        
        ReplaceValue(UserTags.FirstNameParent);
        ReplaceValue(UserTags.SecondNameParent);
        ReplaceValue(UserTags.MiddleNameParent);
        
        ReplaceValue(UserTags.INN);
        ReplaceValue(UserTags.PhoneNumber);
        ReplaceValue(UserTags.DateOfBrith);
        
        ReplaceValue(StudentTags.Course);
        ReplaceValue(StudentTags.Group);
        ReplaceValue(StudentTags.DirectionOfStudy);
        ReplaceValue(StudentTags.ServiceNumber);
        ReplaceValue(StudentTags.DateOfEnd);
        
        ReplaceValue(EmployeeTags.Post);
        ReplaceValue(EmployeeTags.Institute);
        
        CloseDocument();
    }


    private void ReplaceValue(string tag, string? value = null)
    {
        var find = _application.Selection.Find;
        
        find.Text = $"«{tag}»";

        find.Replacement.Text = value ?? string.Empty;
        

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
    public const string FullName = "ФИО";
    public const string FullNameParent = "ФИО-Р";
    
    public const string FirstName = "ИМЯ";
    public const string SecondName = "ФАМИЛИЯ";
    public const string MiddleName = "ОТЧЕСТВО";
    
    public const string FirstNameParent = "ИМЯ-Р";
    public const string SecondNameParent = "ФАМИЛИЯ-Р";
    public const string MiddleNameParent = "ОТЧЕСТВО-Р";
    
    public const string DateOfBrith = "ДАТА РОЖДЕНИЯ";

    
    public const string INN = "ИНН";
    public const string PhoneNumber = "ТЕЛЕФОН";
}

public static class StudentTags
{
    public const string Course = "КУРС";
    public const string Group = "ГРУППА";
    public const string DirectionOfStudy = "КОД И НАИМЕНОВАНИЕ СПЕЦИАЛЬНОСТИ/НАПРАВЛЕНИЯ ПОДГОТОВКИ";
    public const string ServiceNumber = "НОМЕР";
    public const string DateOfEnd = "ДАТА ОКОНЧАНИЯ ИНСТИТУТА";
}

public static class EmployeeTags
{
    public const string Post = "ДОЛЖНОСТЬ";
    public const string Institute = "ИНСТИТУТ";
}