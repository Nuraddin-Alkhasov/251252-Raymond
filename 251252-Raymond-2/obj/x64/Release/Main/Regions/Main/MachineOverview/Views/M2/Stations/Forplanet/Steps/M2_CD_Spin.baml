   M S B A M L   `   `   `  ����   251252-Raymond-2(    "HMI.MainRegion.MO.Views.M2_CD_Spin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   -   $��Center=�$��Center=�  J� Opacity$  0Q�.��  VisiWin.Controls.GroupBox  $��0,0,0,0q�   GB_Group#���      LocalizableHeaderText$ @RecipeSystem.Text60��$��Center=�$	��Top=�.���� $��0q�.+�"  VisiWin.Controls.RadioButton  -     Name$ s1��  RB_Group#���  $��-2q�{�.   d� 	IsChecked$
 TrueY�   LocalizableLabelText$ @RecipeSystem.Text52��.����  �� Orientation$ 
Horizontal=�$��5,10,5,5q�.+��� $��0,0,5,0q�.+�$  VisiWin.Controls.NumericVarOut    NVO_Main#���  $	��200��$
��Bold"�$��45��   LocalizableUnitText$ @Units.s��*  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @RecipeSystem.Text56��   RawLimitMax$ 59Q�	   RawLimitMin$	 0Q�
   FormatString$
 0��   VariableName$i cCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.1.Time��  #���  $
��Bold"�$��45��$��0,5,0,0q�$ 
@Units.rpm��$ @RecipeSystem.Text55��$	 210Q�$	 0Q�$
 0��$j dCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.1.Rotor��  #���  $	��200��$
��Bold"�$��95��$��25(�$ @Units.s��$ @MachineOverview.Text28��$ 59Q�$	 0Q�$
 0��$g aCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Actual.Spinning.1.Time��  -   $ s2��#���  {�.  $��-2q�$ @RecipeSystem.Text53��.���� $ 
Horizontal=�$��5,10,5,5q�.+��� $��0,0,5,0q�.+�  #���  $	��200��$
��Bold"�$��45��$ @Units.s��$ @RecipeSystem.Text56��$ 59Q�$	 0Q�$
 0��$i cCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.2.Time��  #���  $
��Bold"�$��45��$��0,5,0,0q�$ 
@Units.rpm��$ @RecipeSystem.Text57��$	 210Q�$	 0Q�$
 0��$j dCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.2.Rotor��  #���  $
��Bold"�$��45��$��0,5,0,0q�$ 
@Units.rpm��$ @RecipeSystem.Text58��$ 3Q�$	 -3Q�$
 0��$k eCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.2.Planet��  #���  $	��200��$
��Bold"�$	��145��$��25(�$ @Units.s��$ @MachineOverview.Text28��$ 59Q�$	 0Q�$
 0��$g aCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Actual.Spinning.2.Time��  -   $ s3��#���  {�.  $��-2q�$ @RecipeSystem.Text54��.���� $ 
Horizontal=�$��5,10,5,5q�.+��� $��0,0,5,0q�.+�  #���  $	��200��$
��Bold"�$��45��$ @Units.s��$ @RecipeSystem.Text56��$ 59Q�$	 0Q�$
 0��$i cCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.3.Time��  #���  $
��Bold"�$��45��$��0,5,0,0q�$ 
@Units.rpm��$ @RecipeSystem.Text55��$	 210Q�$	 0Q�$
 0��$j dCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Set.Data.Spinning.3.Rotor��  #���  $	��200��$
��Bold"�$��95��$��25(�$ @Units.s��$ @MachineOverview.Text28��$ 59Q�$	 0Q�$
 0��$g aCPU3.PLC.Blocks.03 Basket coating.01 CD.00 Main.Program.DB Program control.Actual.Spinning.3.Time��