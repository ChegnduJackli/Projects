using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMigration
{
    class AGDAPP02PCLS : IMigration
    {
        string PRD_Assb_ccdgConstants = @"D:\agdassb\scripts\agd_assb\include\ccdgConstants.inc";
        string PRD_HelpDesk_WebConfig = @"D:\agdhelpdesk\scripts\agd_helpdesk\Web.config";
        string PRD_MBS_pubpassword = @"D:\agdmbs\app\script\vendorpayment\pubpassword.inc";
        string PRD_MBS_Admin_pubpassword = @"D:\agdmbs\app\script\vendorpayment\administrator\pubpassword.inc";
        string PRD_ReqSys_batch_SrsCommon = @"D:\agdreqsys\batchjob\agd_reqsys\srs_common.vbs";
        string PRD_ReqSys_Script_WebConfig = @"D:\agdreqsys\scripts\agd_reqsys\Web.config";
        string PRD_Vendors_batch_batchInv = @"D:\agdvendors\batchjob\agd_vendors\batchinvoice\ClearBatchInv.vbs";
        string PRD_Vendors_Script_Webconfig = @"D:\agdvendors\script\agd_vendors\Web.config";

        string Local_Assb_ccdgConstants = @"D\agdassb\scripts\agd_assb\include\ccdgConstants.inc";
        string Local_HelpDesk_WebConfig = @"D\agdhelpdesk\scripts\agd_helpdesk\Web.config";
        string Local_MBS_pubpassword = @"D\agdmbs\app\script\vendorpayment\pubpassword.inc";
        string Local_MBS_Admin_pubpassword = @"D\agdmbs\app\script\vendorpayment\administrator\pubpassword.inc";
        string Local_ReqSys_batch_SrsCommon = @"D\agdreqsys\batchjob\agd_reqsys\srs_common.vbs";
        string Local_ReqSys_Script_WebConfig = @"D\agdreqsys\scripts\agd_reqsys\Web.config";
        string Local_Vendors_batch_batchInv = @"D\agdvendors\batchjob\agd_vendors\batchinvoice\ClearBatchInv.vbs";
        string Local_Vendors_Script_Webconfig = @"D\agdvendors\script\agd_vendors\Web.config";

        Common common = new Common();

        string AGDAPP02P_Local_Path = Common.Local_Path_AGDAPP02P;

        public void DoMigration()
        {
            //migration ASSB
            common.DoFileMigration(Local_Assb_ccdgConstants, PRD_Assb_ccdgConstants, AGDAPP02P_Local_Path);
            //migration HelpDesk
            common.DoFileMigration(Local_HelpDesk_WebConfig, PRD_HelpDesk_WebConfig, AGDAPP02P_Local_Path);
            ////migration MBS
            common.DoFileMigration(Local_MBS_pubpassword, PRD_MBS_pubpassword, AGDAPP02P_Local_Path);
            common.DoFileMigration(Local_MBS_Admin_pubpassword, PRD_MBS_Admin_pubpassword, AGDAPP02P_Local_Path);
            //migration SRS
            common.DoFileMigration(Local_ReqSys_batch_SrsCommon, PRD_ReqSys_batch_SrsCommon, AGDAPP02P_Local_Path);
            common.DoFileMigration(Local_ReqSys_Script_WebConfig, PRD_ReqSys_Script_WebConfig, AGDAPP02P_Local_Path);
            //migration Vendors
            common.DoFileMigration(Local_Vendors_batch_batchInv, PRD_Vendors_batch_batchInv, AGDAPP02P_Local_Path);
            common.DoFileMigration(Local_Vendors_Script_Webconfig, PRD_Vendors_Script_Webconfig, AGDAPP02P_Local_Path);
        }
    }
}
