namespace WebApi.Services;

using Microsoft.Office.Interop.Word;

public class AutoStatementService
{
    private readonly Application _application;
    
    public AutoStatementService(string path)
    {
        _application = new Application();

        Object filePath = path;
        
        _application.Documents.Open(ref filePath);
    }
    
    
    public void Example()
    {
        
        ReplaceValue("<tag>", "{Хуй}");
        CloseDocument();
    }

    public void ReplaceValue(string tag, string value)
    {
        var find = _application.Selection.Find;
        var missing = Type.Missing;
        
        find.Text = tag;
        find.Replacement.Text = value;
        
        
        Object wrap = WdFindWrap.wdFindContinue;
        Object replace = WdReplace.wdReplaceOne;
        find.Execute(FindText: Type.Missing,
            MatchCase: false,
            MatchWholeWord: false,
            MatchWildcards: false,
            MatchSoundsLike: missing,
            MatchAllWordForms: false,
            Forward: true,
            Wrap: wrap,
            Format: false,
            ReplaceWith: missing, Replace: replace);
    }
    
    public void CloseDocument()
    {
        _application.ActiveDocument.Save();
        _application.ActiveDocument.Close();
        _application.Quit(); 
    }
}