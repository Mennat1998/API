﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.DAL.Data.Models;

public class Departments
{
    public int Id { get; set; }

    public string Name { get; set; }=string.Empty;

    public ICollection<Ticket> Tickets { get; set; }=new HashSet<Ticket>();
}
