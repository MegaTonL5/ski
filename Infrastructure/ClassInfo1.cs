using System;

namespace Infrastructure
{
    public class ClassInfo1
    {
        //this is a classlib which contains database related 
    //to be useable 
    /*
        1. locate the sln
        2. need to add class library project to solution using
            dotnet sln add Infrastructure 
        3. setup dependency
            1. go to api 
            2. using this command: dotnet add refrence ../Infrastructure 

        4. then locate sln and use the command dotnet restore
    */
    }
}
