using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using ToDoApplication.Model;
using ToDoApplication.Repositories;

namespace ToDoApplication.ViewModels
{
    internal class ToDoItemTagsViewModel : ValidationViewModelBase
	{
		private ITagRepository _tagRepository;
		public Guid Id { get; set; }
		//public string Name { get; set; }

		public ObservableCollection<Color> AvailableTagColors { get; set; }

		private TagColor _color;

		public TagColor Color
		{
			get { return _color; }
			set
			{ 
				_color = value;
				_tagRepository.Update(createModel());
			}
		}


		private string _name;

		public string Name
		{
			get { return _name; }
			set
			{ 
				_name = value;
				if(ValidateName())
				{ 
				_tagRepository.Update(createModel());
				}
			}
		}

		private bool ValidateName()
		{
			//validate that name is not empty
			if (string.IsNullOrEmpty(Name))
			{
				SetError(nameof(Name), "Tag Cannot be empty");
				return false;
			}
			//validate that name is unique
			else if(NameIsNotUnique())
			{
				SetError(nameof(Name), "Tagname Must be unique");
				return false;
			}else
			{
				Reseterror(nameof(Name));
				return true;
			}
				
		}

		private bool NameIsNotUnique()
		{
			var otherTagNames = _tagRepository.GetAll()
						   .Where(tag => tag.Id != this.Id)
						   .Select(tag => tag.Name);
			return otherTagNames.Contains(Name);           
		   
		}

		public  ToDoItemTagsViewModel (ToDoItemTags tags,ITagRepository tagRepository)
		{
		
			Id = tags.Id;
			_name = tags.Name;
			_color = tags.Color;
			_tagRepository = tagRepository;
		}

		public ToDoItemTags createModel()
		{
			return new ToDoItemTags
			{
				Id = Id,
				Name = Name,
				Color=Color
			};
		}

	
	}
}
