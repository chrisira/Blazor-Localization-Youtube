namespace Locale.Helpers
{
    public class LocalizationHelper
    {
        private readonly IConfiguration _config;

        public LocalizationHelper(IConfiguration config)
        {
            _config = config;
        }
        public RequestLocalizationOptions GetLocalizationOptions()
        {
            var cultures = _config.GetSection("Cultures").GetChildren().
                ToDictionary(x => x.Key, x => x.Value);
            var supportedCultures = cultures.Keys.ToArray();

            var localizationOptions = new RequestLocalizationOptions().
                AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);

            return localizationOptions;
                

        }
    }
}
