   M S B A M L   `   `   `  ����   251252-Raymond-14    .HMI.MainRegion.Recipes.Views.Recipe_Article_BT   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $��Center=�$��Center=�$
��1200��  J� Opacity$  0Q�.��  VisiWin.Controls.GroupBox  -      GB_Group#���   
 � Tag$ 50��   LocalizableHeaderText$ @RecipeSystem.Text22��.��� $��0q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�  #���   $��0,0,0,0q�$ 50��$ @RecipeSystem.Text12��.���� $��5,10,5,5q�.+�#  VisiWin.Controls.NumericVarIn  -     Name$	 mcs��  NVI_Main#���  $
��Bold"�$��45��*  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @RecipeSystem.Text41��   LocalizableUnitText$ @Units.grad��   RawLimitMax$	 180Q�	   RawLimitMin$	 60Q�
   FormatString$	
 0.0��   VariableName$P JCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Angle��   AuthorizationRight$ RecipeAP��  $��1��$��0��#���   $ 50��$��0q�$ @RecipeSystem.Text42��.���� $��5,10,5,5q�.+�  -   $	 s0a��#���  $
��Bold"�$��45��$ @Units.grad��$ @RecipeSystem.Text46��$	 180Q�$	 60Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Angle��$ RecipeAP��  -   $	 s0s��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.grad_sec��$ @RecipeSystem.Text47��$ 60Q�$		 0.1Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Speed��$ RecipeAP��  -   $	 s0w��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.s��$ @RecipeSystem.Text32��$ 10Q�$		 0.1Q�$	
 0.0��$W QCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Wait��$ RecipeAP��  VisiWin.Controls.Switch  -     Name$	 s0r��  S_Status#���  $
��Bold"�$��45��$��0,5,0,0q�
�������#  VisiWin.Controls.ToggleButton   LocalizableLabelText$ @RecipeSystem.Text82��   VariableName$[ UCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[0].Rotation��   AuthorizationRight$ RecipeAP��  $��2��$��0��#���   $ 50��$��0q�$ @RecipeSystem.Text43��.���� $��5,10,5,5q�.+�  -   $	 s1a��#���  $
��Bold"�$��45��$ @Units.grad��$ @RecipeSystem.Text46��$	 180Q�$	 0Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Angle��$ RecipeAP��  -   $	 s1s��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.grad_sec��$ @RecipeSystem.Text47��$ 60Q�$	 0Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Speed��$ RecipeAP��  -	   $	 s1w��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.s��$ @RecipeSystem.Text32��$ 10Q�$	 0Q�$	
 0.0��$W QCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Wait��$ RecipeAP��  -
   $	 s1r��#���  $
��Bold"�$��45��$��0,5,0,0q�
�������$ @RecipeSystem.Text82��$[ UCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[1].Rotation��$ RecipeAP��  $��1��$��2��#���   $ 50��$��0q�$ @RecipeSystem.Text44��.���� $��5,10,5,5q�.+�  -   $	 s2a��#���  $
��Bold"�$��45��$ @Units.grad��$ @RecipeSystem.Text46��$	 180Q�$	 0Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Angle��$ RecipeAP��  -   $	 s2s��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.grad_sec��$ @RecipeSystem.Text47��$ 60Q�$	 0Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Speed��$ RecipeAP��  -   $	 s2w��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.s��$ @RecipeSystem.Text32��$ 10Q�$	 0Q�$	
 0.0��$W QCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Wait��$ RecipeAP��  -   $	 s2r��#���  $
��Bold"�$��45��$��0,5,0,0q�
�������$ @RecipeSystem.Text82��$[ UCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[2].Rotation��$ RecipeAP��  $��2��$��2��#���   $ 50��$��0q�$ @RecipeSystem.Text45��.���� $��5,10,5,5q�.+�  -   $	 s3a��#���  $
��Bold"�$��45��$ @Units.grad��$ @RecipeSystem.Text46��$	 180Q�$	 0Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Angle��$ RecipeAP��  -   $	 s3s��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.grad_sec��$ @RecipeSystem.Text47��$ 60Q�$	 0Q�$	
 0.0��$X RCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Speed��$ RecipeAP��  -   $	 s3w��#���  $
��Bold"�$��45��$��0,5,0,0q�$ @Units.s��$ @RecipeSystem.Text32��$ 10Q�$	 0Q�$	
 0.0��$W QCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Wait��$ RecipeAP��  -   $	 s3r��#���  $
��Bold"�$��45��$��0,5,0,0q�
�������$ @RecipeSystem.Text82��$[ UCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Station.BT.Step[3].Rotation��$ RecipeAP��