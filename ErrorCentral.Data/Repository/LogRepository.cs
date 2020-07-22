using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Data.Repository
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(Context context) : base(context)
        {
        }
    }
}