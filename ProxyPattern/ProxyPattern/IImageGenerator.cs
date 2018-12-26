using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    //Subject
    interface IImageGenerator
    {
        void ShowImage();
    }

    //real subject
    class ImageGenerator : IImageGenerator
    {
        private String _fullPath;

        public ImageGenerator(string fullPath)
        {
            _fullPath = fullPath;
        }
        public void ShowImage()
        {
            Console.WriteLine("{0} resmi gösteriliyor.", _fullPath);
        }
    }

    //proxy

    class ImageGeneratorProxy : IImageGenerator
    {
        private ImageGenerator _generator;
        private string _fullPath;

        public ImageGeneratorProxy(string fullPath)
        {
            _fullPath = fullPath;
        }
        public void ShowImage()
        {
            if (_generator == null)
            {
                _generator = new ImageGenerator(_fullPath);
            }
            _generator.ShowImage();
        }
    }









}


