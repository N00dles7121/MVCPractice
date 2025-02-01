using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs;
using MVCPractice.DataAccess.Data;

namespace DataAccess.Repositories;

public class MovieRepo : Repo<Movie>
{
    private readonly ProgramContext _context;

    public MovieRepo(ProgramContext context) : base(context)
    {
        _context = context;
    }

    public async Task ExecuteUpdateAsync(MovieDTO movieDto, int id)
    {
        var affectedRows = await _context.Movies.Where(m => m.Id == id).ExecuteUpdateAsync(s => s
        .SetProperty(m => m.Title, movieDto.Title)
        .SetProperty(m => m.ReleaseDate, movieDto.ReleaseDate)
        .SetProperty(m => m.Rating, movieDto.Rating)
        .SetProperty(m => m.CategoryId, movieDto.CategoryId));
        // .SetProperty(m => m.Actors, movieDto.Actors));

        await _context.SaveChangesAsync();
    }
}
