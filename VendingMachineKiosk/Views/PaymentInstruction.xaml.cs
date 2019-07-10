﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Command;
using VendingMachineKiosk.ViewModels;
using XiaoTianQuanProtocols;
using XiaoTianQuanProtocols.DataObjects;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VendingMachineKiosk.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PaymentInstruction : Page
    {
        public PaymentInstruction()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter == null)
                throw new ArgumentNullException(nameof(e.Parameter));

            (ProductInformation product, PaymentType payment) = (ValueTuple<ProductInformation, PaymentType>) e.Parameter;
            var viewmodel = (PaymentInstructionViewModel) DataContext;
            viewmodel.PaymentType = payment;
            viewmodel.Slot = product.Slot;
            await viewmodel.LoadAsync();
        }
    }
}
