using System;
using Models;
using MVCPractice.DataAccess.Data;

namespace DataAccess.Repositories;

public class MovieRepo : Repo<Movie>
{
    public MovieRepo(ProgramContext context) : base(context)
    {
    }
}
