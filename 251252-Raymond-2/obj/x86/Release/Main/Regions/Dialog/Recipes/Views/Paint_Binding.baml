   M S B A M L   `   `   `  ����   251252-Raymond-22    ,HMI.DialogRegion.Recipes.Views.Paint_Binding   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�� -    �Name$ border�� J� RenderTransformOrigin$ 1, 0.5&�$
��1000��$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @RecipeSystem.Text106��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *Close+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�&   System.Windows.Controls.DataGrid  -     Name$ 	dgv_bctor��$	��500��$��2q�  FP_BorderBrush#���    DG_StandartC#���  ���� *
Diptanks+ �� SelectedItem �� *SelectedDiptank+   Columns 0  *System.Windows.Controls.DataGridTextColumn    	TB_Center1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 300	    Header 6
  0VisiWin.Extensions.LocalizedTextBindingExtension
   
  LocalizableText$ @RecipeSystem.Text97��   Binding �� *DT+  # �  $ *	  
  $ @RecipeSystem.Text76�� �� *Paint.Header.Name+   VisiWin.Controls.TextVarIn  $��45��  TVI_Main#���  *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @RecipeSystem.Text11��$��0,5,0,0q�   Value �� *Filter+ �� Mode$ TwoWay=��� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�  $��1��$��50��$	��200��   LocalizableText$ @Buttons.Text18��  	B_Blue_ns#���     AuthorizationRight$ RecipeAssignPP������ *Edit+{��� *IsDTToPaintSelected+�� -    ��Name$ dataedit��$��5��$��-10,0q�$ 5��#���   $  0Q�$y�	Collapsed=�._�  VisiWin.Controls.GroupBox  $	��600��$��Center=�$��Center=� 	 GB_Group#��� 	    LocalizableHeaderText$ @RecipeSystem.Text106��.���� $��10q�.+�  #���  $��45��$��0,5,0,0q�$ @RecipeSystem.Text97��   VariableName$ __UNLINKED_BSTR��{�.   �� *SelectedDiptank.DT+$ TwoWay=�  VisiWin.Controls.ComboBox  $��45�� 
 CB_Main#��� 
 $��0,10,0,0q�   LocalizableLabelText$ @RecipeSystem.Text76��   VariableName$ __UNLINKED_I2��    	StateList  �� *
PaintTypes+ �� *SelectedPaint+�� $��0,10,0,0q�.+��� $��3��$��Bottom=�#���  $��2��$ 2��� $��0,10,0,0q�.+�  -   $ btnSave��$��50��$	��200��$
��Left=�$ @Buttons.Text25��#���  $ RecipeAssignPP������ *Save+  -   $ 	btnCancel��$ Löschen��$��50��$	��200��$��Right=�$ @Buttons.Text13��  B_Red_ns#���  $��1������ *CloseEditDialog+� $��5��$��-10,0,-10,0q�#���   y��� *Wait+.+�  
�������$	  0.7Q�$ 10��$��	0,100,0,0q�$	��150��$	��290��$��Center=�$��Center=�   $ 10Q���   FP_Wait#���  $	  0.7Q�$��	0,100,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -   ! ��Name$	! gif��$
��None=�