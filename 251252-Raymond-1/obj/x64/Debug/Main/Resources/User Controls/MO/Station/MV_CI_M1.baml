   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5      ,    &HMI.Resources.UserControls.MO.MV_CI_M1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5      -   5          J� Opacity$  0Q�5   a   .��5      � -   5         �Name$ A��5      .+�5   
   !  VisiWin.Controls.PictureBox     SymbolResourceKey$ 
MV_CI_Rail��6   $��43��67   $	��471��6B   $��7,37,0,3q�6P   $
��Left=�6b   $	��Top=�6}    J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
         Color$ Black��6#      
BlurRadius$ 3Q�61      	Direction$	 270Q�6A      Opacity$	 0.5Q�6R   5      � 5   
   -   5        $	 HVT��5      $
��Left=�6   $��Bottom=�67   $��3,0,0,0q�6R   .+�5        $ MV_CI��6   $��50��67   $��96��6B   $
��Left=�6N    5        5      $ Black��6'   $ 3Q�65   $	 270Q�6E   $	 0.5Q�6V   5      ,   &HMI.Resources.UserControls.MO.MVBasket  5      $��
-3,-26,0,0q�6   $
��Left=�6.   $	��Top=�6I      IsBasket$Q KCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Baskets.Available��5      	   
IsMaterial$P	 JCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Available��5      
   SetLayer$P
 JCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Layer.Set��5         ActualLayer$S MCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Layer.Actual��5      
   CPU$
 CPU1��5      	   AS$	 Set��6'     5      $��	-3,12,0,0q�6   $
��Left=�6-   $	��Top=�6H   $Q KCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Baskets.Available��5      $P	 JCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Available��5      $P
 JCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Layer.Set��5      $S MCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Charge.Layer.Actual��5          IsDischarge$[ UCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Baskets.Functions.Discharge��5!         IsWatch$W QCPU1.PLC.Blocks.02 Basket handling.05 CI.00 Main.DB CI PD.Baskets.Functions.Watch��5"         Station$ 4��5#      $
 CPU1��6'   $ Actual��62   5&        VisiWin.Controls.Button  5(   
   -   5           
B_Material#���   5(      $��-5,-5,-5,-100q�69   6P   5+      5-      