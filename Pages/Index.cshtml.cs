using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;

namespace markharrisonappcfg.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Config config;
        public IFeatureManager featureManager;
        public string featuredata = "";

        public IndexModel(ILogger<IndexModel> logger, IOptionsSnapshot<Config> options, IFeatureManager fm)
        {
            _logger = logger;
            config = options.Value;
            featureManager = fm;
        }

        async public void OnGet()
        {
            if (await featureManager.IsEnabledAsync("beta"))
            {
                featuredata += "beta " ;
            }
            if (await featureManager.IsEnabledAsync("FeatureA"))
            {
                featuredata += "FeatureA";
            }


        }
    }
}
