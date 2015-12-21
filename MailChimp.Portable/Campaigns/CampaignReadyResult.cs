using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Campaigns
{
    
    class CampaignReadyResult
    {
        public bool IsReady { get; set; }

        public List<CampaignReadyCheckItem> Items { get; set; }
    }
}
