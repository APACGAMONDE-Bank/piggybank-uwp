﻿using Microsoft.Toolkit.Uwp.Notifications;
using piggy_bank_uwp.Models;
using piggy_bank_uwp.Services;
using piggy_bank_uwp.Utilities;
using piggy_bank_uwp.ViewModel.Tag;
using piggy_bank_uwp.ViewModels.Interface;
using piggy_bank_uwp.Workers;
using System;
using System.Linq;
using Windows.UI.Notifications;

namespace piggy_bank_uwp.ViewModel.Cost
{
    public class CostViewModel : BaseViewModel, IUpdateable
    {
        public CostViewModel()
        {
            Model = new CostModel { Id = SystemUtility.GetGuid() };
            IsNew = true;
        }

        internal CostViewModel(CostModel model)
        {
            Model = model;
            Category = MainViewModel.Current.Categories.FirstOrDefault(t => t.Id == CategoryId);
            IsNew = false;
        }

        public void Update()
        {
            RaisePropertiesChanged();
        }

        public bool IsNew { get; private set; }

        public string Comment
        {
            get
            {
                return Model.Comment;
            }
            set
            {
                if (Model.Comment != value)
                {
                    Model.Comment = value;
                }
            }
        }

        public int Cost
        {
            get
            {
                return Model.Cost;
            }
            set
            {
                if (Model.Cost != value)
                {
                    Model.Cost = value;
                }
            }
        }

        public DateTimeOffset DateOffset
        {
            get
            {
                return DateUtility.GetDateTime(Model.Date);
            }
            set
            {
                Model.Date = DateUtility.GetTimeUtc(value);
            }
        }

        public string Date
        {
            get
            {
                string format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;                
                return DateUtility.GetDateTime(Model.Date).Date.ToString(format);
            }
        }

        public string CostWithCurrency
        {
            get
            {
                return Model.Cost + MainViewModel.Current.Balance.Currency;
            }
        }

        public string Id
        {
            get
            {
                return Model.Id;
            }
        }

        public string CategoryId
        {
            get
            {
                return Model.CategoryId;
            }
        }

        public CategoryViewModel Category
        {
            get
            {
                return MainViewModel.Current.Categories.FirstOrDefault(c => c.Id == CategoryId);
            }
            set
            {
                Model.CategoryId = value.Id;
            }
        }

        internal CostModel Model { get; }

    }
}
