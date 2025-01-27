﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Quiz.Supports.Extensions;
using Quiz.Supports.PropertyAnimationHandlers;

namespace Quiz.ViewModel
{
    public class MainViewInteractionsVM : BindableBase
    {

        public MainViewInteractionsVM()
        {
            Application.Current.MainWindow.KeyDown += (s, e) => {
                switch (e.Key)
                {
                    case Key.Q:
                        OpenQuestionsAnimationTrigger =
                     OtherExtensions.ReverceAnimationTriggerValue(OpenQuestionsAnimationTrigger);
                        break;
                }
            };

            SettingsIconClickCommand = new DelegateCommand(() =>
               OpenSettingsAnimationTrigger =
                    OtherExtensions.ReverceAnimationTriggerValue(OpenSettingsAnimationTrigger)
            );
        }

        private AnimationTriggerValue _openSettingsAnimationTrigger = AnimationTriggerValue.StartReverce;
        public AnimationTriggerValue OpenSettingsAnimationTrigger
        {
            get => _openSettingsAnimationTrigger;
            set {
                if (value == AnimationTriggerValue.Start && _openQuestionsAnimationTrigger == AnimationTriggerValue.Start) {
                    _openQuestionsAnimationTrigger = AnimationTriggerValue.StartReverce;
                    RaisePropertyChanged("OpenQuestionsAnimationTrigger");
                }

                SetProperty(ref _openSettingsAnimationTrigger, value);
            }
        }

        private AnimationTriggerValue _openQuestionsAnimationTrigger = AnimationTriggerValue.StartReverce;
        public AnimationTriggerValue OpenQuestionsAnimationTrigger
        {
            get => _openQuestionsAnimationTrigger;
            set {
                if (value == AnimationTriggerValue.Start && _openSettingsAnimationTrigger == AnimationTriggerValue.Start) {
                    _openSettingsAnimationTrigger = AnimationTriggerValue.StartReverce;
                    RaisePropertyChanged("OpenSettingsAnimationTrigger");
                }

                SetProperty(ref _openQuestionsAnimationTrigger, value);
            }
        }

        public DelegateCommand SettingsIconClickCommand { get; }
        public DelegateCommand CloseClick { get; }
    }
}
