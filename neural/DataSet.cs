using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AIMLTGBot;

namespace NeuralNetwork1
{
    public class DataSet
    {

        static Random rand = new Random();
        private static Dictionary<string, FigureType> Classes = new Dictionary<string, FigureType>()
        {
            {"0", FigureType.Zero }, {"1", FigureType.One}, {"2", FigureType.Two}, {"3", FigureType.Three},
            {"4", FigureType.Four}, {"5", FigureType.Five}, {"6", FigureType.Six}, {"7", FigureType.Seven},
            {"8", FigureType.Eight}, {"9", FigureType.Nine}
        };

        public static SamplesSet GetDataSet(string path = "../../mydataset/")
        {
            SamplesSet s = new SamplesSet();
            void LoadClass(string subdir)
            {
                foreach (var file in Directory.GetFiles(Path.Combine(path, subdir)))
                {
                    // if (rand.Next(0, 100) > 10) continue;
                    Bitmap f = new Bitmap(file);
                    s.AddSample(new Sample(ImageHelper.GetArray(f), 10, Classes[subdir]));
                }
            }

            foreach (var subdir in Directory.GetDirectories(path))
            {
                LoadClass(Path.GetFileName(subdir));
            }

            s.samples = s.samples.OrderBy(i => rand.Next()).ToList();
            
            return s;
        }
    }
}
