using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10._0_GC
{
    class Movie
    {
        //fields
        private string title;
        private string category;

        //properties
        public string Title 
        { 
            get 
            {
                return title;
            } 
            set 
            {
                title = value;
            } 
        }

        public string Category 
        {
            get 
            {
                return category;
            } set 
            {
                category = value;
            } 
        }

        //constructors
        public Movie(string _title, string _genre)
        {
            title = _title;
            category = _genre.ToLower();
        }

        public Movie(string[] line) : this(line[0], line[1]) { }

        //methods
    }
}
