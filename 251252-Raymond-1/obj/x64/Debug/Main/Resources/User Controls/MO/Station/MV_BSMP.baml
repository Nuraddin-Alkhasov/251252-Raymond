   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5   	   +    %HMI.Resources.UserControls.MO.MV_BSMP   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   	   6UC+clr-namespace:HMI.Resources.UserControls.MO   5   	   -   5          J� Opacity$  0Q�5   \   .��5      � -   5         �Name$ A��5      .+�5   
   !  VisiWin.Controls.PictureBox     SymbolResourceKey$ MV_BS��6   $	��110��62   $��83��6>   $��
98,442,0,0q�6J   $
��Left=�6^   $��Bottom=�6y   $��1��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5	         Color$ Black��6#      
BlurRadius$ 3Q�61      	Direction$	 270Q�6A      Opacity$	 0.5Q�6R   5        5   
   -   5          Name$ ManiPosition��5      $ MV_MP1��6.   $	��500��6I   $	��500��6U   $��3,3,0,0q�6b   $	��Top=�6s   $
��Left=�6�   $��2��6�    5        5      $ Black��6#   $ 3Q�61   $	 270Q�6A   $	 0.5Q�6R   5      ,   &HMI.Resources.UserControls.MO.MVBasket  5   
   $��
99,411,0,0q�6   $
��Left=�6*   $	��Top=�6E   	   IsBasket$P	 JCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Available��5      
   
IsMaterial$O
 ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Available��5         SetLayer$O ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Set��5         ActualLayer$R LCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Actual��5         IsDischarge$Z TCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Functions.Discharge��5         IsWatch$V PCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Functions.Watch��5      
   CPU$
 CPU1��5         Station$ 4��6$   	   AS$	 Set��60   $��1��69     5   
   $��150,427,0,0q�6   $
��Left=�6,   $	��Top=�6G   $P	 JCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Available��5      $O
 ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Available��5      $O ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Set��5      $R LCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Actual��5      $
 CPU1��5       $ Actual��6"   $��1��6.   � 5"   
   -   5        $ B��5"      $��2��6   5$        VisiWin.Controls.Button  5&   
   -   5          Name$ bhMode��5&      $��60��6$   $	��100��60    
  B_Gray#���   6<   $��0q�6]   {�.  $  1Q�6{   $��14(�6�   $��Center=�6�   $��	10,60,0,0q�6�   $	��Top=�6�   $��Center=�6�     5(   
   -   5          
B_Material#���  5(   ,   $��75,106,100,124q�6Q   $��1��6i     5)   
   -   5        #���  5)   ,   $��30,400,280,-5q�6Q   $��1��6h   5*      5-      