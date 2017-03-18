﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProject.Models;

namespace TermProject.Repositories
{
    public interface IProfileRepository
    {
        IEnumerable<Profile> GetAllProfiles();
        List<Profile> GetProfilesByCity(string city);
    }
}