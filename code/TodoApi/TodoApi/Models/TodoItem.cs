using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
# Add a model class

A model is an object that represents the data in the app. In this case, the only model is a to-do item.
Add a folder named "Models". In Solution Explorer, right-click the project. Select Add > New Folder. Name the folder Models.
Note: The model classes go anywhere in the project. The Models folder is used by convention for model classes.2
Add a TodoItem class. Right-click the Models folder and select Add > Class. Name the class TodoItem and select Add 
The database generates the Id when a TodoItem is created.
*/


namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set;}
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
