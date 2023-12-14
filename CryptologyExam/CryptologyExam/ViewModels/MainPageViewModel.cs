using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CryptologyExam.Enums;
using CryptologyExam.Services.Interfaces;
using Prism.Navigation;
using Xamarin.Forms;

namespace CryptologyExam.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAffineService _affineService;
        private readonly IAtbashService _atbashService;
        private readonly ISezarService _sezarService;

        private ObservableCollection<AlgorithmTypeEnum> algoritmList = new ObservableCollection<AlgorithmTypeEnum>();
        public ObservableCollection<AlgorithmTypeEnum> AlgorithmList
        {
            get
            {
                return algoritmList;
            }
            set
            {
                algoritmList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<OperationTypeEnum> operationTypeList = new ObservableCollection<OperationTypeEnum>();
        public ObservableCollection<OperationTypeEnum> OperationTypeList
        {
            get
            {
                return operationTypeList;
            }
            set
            {
                operationTypeList = value;
                RaisePropertyChanged();
            }
        }

        private string _cryptionPlainText;
        public string CryptionPlainText
        {
            get
            {
                return _cryptionPlainText;
            }
            set
            {
                _cryptionPlainText = value; RaisePropertyChanged();
            }
        }

        private string _resultPlainText;
        public string ResultPlainText
        {
            get
            {
                return _resultPlainText;
            }
            set
            {
                _resultPlainText = value; RaisePropertyChanged();
            }
        }

        private OperationTypeEnum _selectedOperationType;
        public OperationTypeEnum SelectedOperationType
        {
            get
            {
                return _selectedOperationType;
            }
            set
            {
                _selectedOperationType = value; RaisePropertyChanged();
            }
        }

        private AlgorithmTypeEnum _selectedAlgorithmType;
        public AlgorithmTypeEnum SelectedAlgorithmType
        {
            get
            {
                return _selectedAlgorithmType;
            }
            set
            {
                _selectedAlgorithmType = value; RaisePropertyChanged();
            }
        }

        private int _numberA;
        public int NumberA
        {
            get
            {
                return _numberA;
            }
            set
            {
                _numberA = value; RaisePropertyChanged();
            }
        }
        private int _numberB;
        public int NumberB
        {
            get
            {
                return _numberB;
            }
            set
            {
                _numberB = value; RaisePropertyChanged();
            }
        }

        private int _shiftAmount;
        public int ShiftAmount
        {
            get
            {
                return _shiftAmount;
            }
            set
            {
                _shiftAmount = value; RaisePropertyChanged();
            }
        }



        public MainPageViewModel(INavigationService navigationService, IAtbashService atbashService, ISezarService sezarService, IAffineService affineService) : base(navigationService)
        {
            _atbashService = atbashService;
            _affineService = affineService;
            _sezarService = sezarService;
            _navigationService = navigationService;
            algoritmList.Add(AlgorithmTypeEnum.Atbash);
            algoritmList.Add(AlgorithmTypeEnum.Sezar);
            algoritmList.Add(AlgorithmTypeEnum.Affine);

            operationTypeList.Add(OperationTypeEnum.encryption);
            operationTypeList.Add(OperationTypeEnum.decryption);

        }

        // ortak bölenlerini buluyor
        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // A ve B'nin aralarında asal olup olmadığını kontrol eden fonksiyon
        static bool AreCoprime(int a, int b)
        {
            return GCD(a, b) == 1;
        }


        public ICommand ApplyCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (_cryptionPlainText != "" && _cryptionPlainText.Length > 0)
                    {
                        if (SelectedAlgorithmType == AlgorithmTypeEnum.Atbash && SelectedOperationType == OperationTypeEnum.encryption)
                        {
                            var result = _atbashService.EncryptAtbash(_cryptionPlainText);
                            ResultPlainText = result;

                        }
                        else if (SelectedAlgorithmType == AlgorithmTypeEnum.Atbash && SelectedOperationType == OperationTypeEnum.decryption)
                        {
                            var result = _atbashService.DecryptAtbash(_cryptionPlainText);
                            ResultPlainText = result;
                        }
                        else if (SelectedAlgorithmType == AlgorithmTypeEnum.Sezar && SelectedOperationType == OperationTypeEnum.encryption)
                        {
                            if (ShiftAmount >= 0)
                            {
                                var result = _sezarService.EncryptSezar(_cryptionPlainText, ShiftAmount);
                                ResultPlainText = result;
                            }
                            else
                            {

                            }

                        }
                        else if (SelectedAlgorithmType == AlgorithmTypeEnum.Sezar && SelectedOperationType == OperationTypeEnum.decryption)
                        {
                            if (ShiftAmount > 0)
                            {
                                var result = _sezarService.DecryptSezar(_cryptionPlainText, ShiftAmount);
                                ResultPlainText = result;
                            }

                        }
                        else if (SelectedAlgorithmType == AlgorithmTypeEnum.Affine && SelectedOperationType == OperationTypeEnum.encryption)
                        {
                            if (NumberA > 0 && NumberB > 0)
                            {
                                if (AreCoprime(NumberA, NumberB))
                                {
                                    var result = _affineService.EncryptAffine(_cryptionPlainText, NumberA, NumberB);
                                    ResultPlainText = result;
                                }
                            }

                        }
                        else if (SelectedAlgorithmType == AlgorithmTypeEnum.Affine && SelectedOperationType == OperationTypeEnum.decryption)
                        {
                            if (NumberB > 0)
                            {
                                if (AreCoprime(NumberA, NumberB))
                                {
                                    var result = _affineService.DecryptAffine(_cryptionPlainText, NumberA, NumberB);
                                    ResultPlainText = result;

                                }
                            }

                        }
                        else
                        {
                            ResultPlainText = "yapılamadı";
                        }
                    }

                });
            }
        }

    }
}

