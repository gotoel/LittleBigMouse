﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLab.Notify
{
    public interface INotifierObject : INotifyPropertyChanged
    {
        Notifier Notifier { get; }
    }

    [DataContract]
    public class NotifierObject : INotifierObject
    {
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => this.Add(value);
            remove => this.Remove(value);
        }

        protected NotifierObject(bool init = true)
        {
            //_notifier = new Lazy<Notifier>(()=>NotifierService.D.GetNotifier(this)) ;
            Notifier = NotifierService.D.GetNotifier(this);
            if(init) Notifier.Subscribe(this);
        }

        //private readonly Lazy<Notifier> _notifier;
        public Notifier Notifier { get; }//=> _notifier.Value;
    }
}
