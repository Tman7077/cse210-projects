using System;
//www.plantuml.com/plantuml/png/ROqn2i9044NxESMKYdY1HIIWZM1jAqko9WExCvBv4IHuTma6JM7v7v_tAaViCPHCTOxkV94c6OsqvIi4EGLszABj1EA0pleboKbRT855CStQIaaA3tmMn-xmcNkY3H_5xpa-JtgprJhmmwIXrzoSVpJ-ZzIcI8el-jaMfYffCvJy1W00
class Program
{
    static void Main(string[] args)
    {
        List<Video> vl = new List<Video>();
        for (int i = 1; i < new Random().Next(4,6); i++)
        {
            Video v = new Video($"Title {i}", $"Author {i}", new Random().Next(1,86399));
            for (int j = i; j < i + new Random().Next(3,5); j++)
            {
                v.AddComment(new Comment($"Commenter {j}", $"Comment content {j}"));
            }
            vl.Add(v);
        }
        foreach (Video v in vl)
        {
            v.DisplayInfo();
        }
    }
}