using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMigration
{
    class AGDAPP04PCLS : IMigration
    {
        string PRD_HelpDesk_Batch_Common = @"D:\agdhelpdesk\batchjob\agd_helpdesk\common.vbs";
        string PRD_HelpDesk_Script_WebConfig = @"D:\agdhelpdesk\scripts\agd_helpdesk\Web.config";
        string PRD_Vendors_Script_WebConfig = @"D:\agdvendors\script\agd_admin\web.config";

        string Local_HelpDesk_Batch_Common = @"D\agdhelpdesk\batchjob\agd_helpdesk\common.vbs";
        string Local_HelpDesk_Script_WebConfig = @"D\agdhelpdesk\scripts\agd_helpdesk\Web.config";
        string Local_Vendors_Script_WebConfig = @"D\agdvendors\script\agd_admin\web.config";

        Common common = new Common();

        string AGDAPP04P_Local_Path = Common.Local_Path_AGDAPP04P;

        public void DoMigration()
        {
            common.DoFileMigration(Local_HelpDesk_Batch_Common, PRD_HelpDesk_Batch_Common, AGDAPP04P_Local_Path);
            common.DoFileMigration(Local_HelpDesk_Script_WebConfig, PRD_HelpDesk_Script_WebConfig, AGDAPP04P_Local_Path);
            common.DoFileMigration(Local_Vendors_Script_WebConfig, PRD_Vendors_Script_WebConfig, AGDAPP04P_Local_Path);
        }
    }
}
