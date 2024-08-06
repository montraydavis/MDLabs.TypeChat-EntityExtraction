using System.Data.Common;
using System.Text;
using System.Text.Json;
using MDLabs.TypeChatEntityExtraction;
using MDLabs.TypeChatEntityExtraction.Schemas;
using Microsoft.Playwright;
using Microsoft.TypeChat;

public class BrowserApp : ConsoleApp
{
    IPlaywright? _playwright;
    IBrowserContext? _context;
    IBrowser? _browser;
    IPage? _page;

    protected IPage Page => _page ?? throw new Exception("Playwright has not been initialized.");
    private AppConfig _appConfig;
    JsonTranslator<NamedEntitiesSchema> _translator;

    public override async Task RunAsync(string consolePrompt, string? userPrompt = null, string? inputFilePath = null)
    {
        ConsolePrompt = consolePrompt;
        await InitApp();
        if (string.IsNullOrEmpty(inputFilePath))
        {
            await RunAsync(userPrompt, default(CancellationToken));
        }
        else
        {
            await RunBatchAsync(inputFilePath);
        }
    }

    public BrowserApp()
    {
        OpenAIConfig config = Config.LoadOpenAI();

        this._appConfig = Config.LoadAppConfig();
        this._translator = new JsonTranslator<NamedEntitiesSchema>(new LanguageModel(config));
    }

    public override async Task ProcessInputAsync(string input, CancellationToken cancelToken)
    {
        var response = await _translator.TranslateAsync(input, cancelToken);

        try
        {
            await HandleIntentAsync(response);
        }
        catch (Exception ex)
        {
            WriteError(ex);
        }

        var sb = new StringBuilder();


        Console.WriteLine(sb.ToString());
    }

    private Task HandleIntentAsync(NamedEntitiesSchema response)
    {
        Console.WriteLine($"Extracted the following named entities:\n\n{JsonSerializer.Serialize(response)}");

        return Task.CompletedTask;
    }

    public static async Task<int> Main(string[] args)
    {
        try
        {
            var app = new BrowserApp();

            var businessReportContent = File.ReadAllText("./docs/BusinessReport.md");
            var newsArticleContent = File.ReadAllText("./docs/NewsArticle.md");
            var medicalRecordContent = File.ReadAllText("./docs/MedicalRecord.md");


            await app.RunAsync("😀> ", businessReportContent, args.GetOrNull(0));
            await app.RunAsync("😀> ", newsArticleContent, args.GetOrNull(0));
            await app.RunAsync("😀> ", medicalRecordContent, args.GetOrNull(0));
        }
        catch (Exception ex)
        {
            WriteError(ex);
            Console.ReadLine();
            return -1;
        }

        return 0;
    }
}