using System;
//www.plantuml.com/plantuml/png/ROqn2i9044NxESMKYdY1HIIWZM1jAqko9WExCvBv4IHuTma6JM7v7v_tAaViCPHCTOxkV94c6OsqvIi4EGLszABj1EA0pleboKbRT855CStQIaaA3tmMn-xmcNkY3H_5xpa-JtgprJhmmwIXrzoSVpJ-ZzIcI8el-jaMfYffCvJy1W00
class Program
{
    static void Main(string[] args)
    {
        List<Video> vl = new List<Video>(); // list of example videos
        int k = 1; // commenter number, tracked outside of video creation

        // create 3-4 videos
        for (int i = 1; i < new Random().Next(4,6); i++)
        {
            Video v = new Video($"Title {i}", $"Author {i}", new Random().Next(1,86400)); // example video, numbered
            int l = k; // whatever k was before the following loop

            // create 3-4 comments on each video, but each comment is numbered sequentially regardless of which video it is
            for (int j = k; j < l + new Random().Next(3,5); j++)
            {
                v.AddComment(new Comment($"Commenter {j}", $"Comment content {j}"));
                k++;
            }

            vl.Add(v);
        }

        // display the video and comment info for each video in vl
        foreach (Video v in vl)
        {
            v.DisplayInfo();
        }
    }
}