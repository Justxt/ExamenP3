using ExamenP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3.Services
{
    public interface BaseService
    {
        public Task<List<Chiste>> GetChistes();
    }
}
