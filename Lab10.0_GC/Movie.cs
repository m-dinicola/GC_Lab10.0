using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10._0_GC
{
    class Movie
    {
        //fields
        private string title;           //Lab description specified fields must be used, and named thusly
        private string category;        //though auto-properties could have worked for this.

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
        public Movie(string _title, string _genre)      //if given two strings, will set them as title and genre
        {
            title = _title;
            category = _genre.ToLower();
        }

        public Movie(string[] line) : this(line[0], line[1]) { }  //if given a string array, will set first two strings as title and genre.

        //methods
    }
}
