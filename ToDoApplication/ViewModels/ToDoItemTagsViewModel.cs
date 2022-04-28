﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ToDoApplication.Model;
using ToDoApplication.Repositories;

namespace ToDoApplication.ViewModels
{
    internal class ToDoItemTagsViewModel
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
				_tagRepository.Update(createModel());
			
			}
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
