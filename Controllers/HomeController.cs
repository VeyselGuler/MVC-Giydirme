using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogAppMor.Models;

namespace BlogAppMor.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var blogs = getAllBlogs();
        
        return View(blogs);
    }

    public IActionResult Detay(string id)
    {
        using StreamReader reader = new StreamReader($"AppData/posts/{id}.txt");
        ViewData["content"] = reader.ReadToEnd();
        
        return View();
    }

    public IActionResult Hakkimda()
    {
        return View();
    }

    public IActionResult Iletisim()
    {
        return View();
    }
    public List<Blog> getAllBlogs()
    {
        var blogs = new List<Blog>();
        using StreamReader reader = new StreamReader("AppData/posts/index.txt");
        var blogsTxt = reader.ReadToEnd();

        var blogsLines = blogsTxt.Split('\n');
        foreach (var item in blogsLines)
        {
            var blogParts = item.Split('|');
            blogs.Add(
                new Blog()
                {
                    Title = blogParts[0],
                    Summary = blogParts[1],
                    ImgUrl = blogParts[2],
                    Slug = blogParts[3]
                }
            );
        }

        return blogs;
    }
}