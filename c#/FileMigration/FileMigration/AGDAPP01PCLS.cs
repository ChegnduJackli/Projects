using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMigration
{
    class AGDAPP01PCLS : IMigration
    {
        string PRD_Group1_Properties = @"D:\agdcms\batchjobs\group1_2\bin\app.properties";
        string PRD_Group3_Properties = @"D:\agdcms\batchjobs\group3\bin\app.properties";

        string Local_Group1_Properties = @"D\agdcms\batchjobs\group1_2\bin\app.properties";
        string Local_Group3_Properties = @"D\agdcms\batchjobs\group3\bin\app.properties";


        Common common = new Common();

        string AGDAPP01P_Local_Path = Common.Local_Path_AGDAPP01P;


        public void DoMigration()
        {
            common.DoFileMigration(Local_Group1_Properties, PRD_Group1_Properties, AGDAPP01P_Local_Path);
            common.DoFileMigration(Local_Group3_Properties, PRD_Group3_Properties, AGDAPP01P_Local_Path);
        }
      
    }
}
