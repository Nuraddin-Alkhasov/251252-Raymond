   M S B A M L   `   `   `  ����   251252-Raymond-1#    HMI.HeaderRegion.Views.Header   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $��80��$
��1920��   BackgroundBrush#���   .��� -     �Name$  
LayoutRoot��.+�  VisiWin.Controls.Button  -     Name$ camera��$��48��$��80��$��	900,0,0,0q�$	��Top=�$��Center=�  B_Peripheral#���   �� 	IsDefault .    SymbolResourceKey$ Camera��   AuthorizationRight$ PDCamera������ *
OpenCamera+  -   $ barcode��$��48��$��80��$��
1100,0,0,0q�$	��Top=�$��Center=�#���   . $ Scanner��$
 PDBS������ *OpenBarcode+  -   $	 eks��$��48��$��80��$��
1300,0,0,0q�$	��Top=�$��Center=�#���   . $	 EKS��$ PDEKS������ *	OpenEKS+   VisiWin.Controls.TextBlock  -     Name$ 	AlarmText�� �� Padding$ 10,5,0,0q�$��0,48,0,0q� 
 FP_Red#���  
�������$��SemiBold"�$��16(����� *	AlarmText+�� 
�������$��3,3,0,0q�$
��Left=�$	��Top=�$��42��$	��110�� �� CornerRadius$ 2��._�&   VisiWin.Controls.SymbolPresenter  $��Center=�$��Center=�  H_ForplanLogo   Symbol# �  �� $��8��$��Stretch=�#���  $��Bottom=�	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   Color$
 White��   	Direction$	 270Q�   Opacity$	 0.7Q�  VisiWin.Controls.Clock  $��Right=�$��12(�$��Normal"����	#FFFFFFFF$��Segoe UI)�$��0,0,8,56q�$	��250��$��24��$��Right=�   
FormatDate$ @NamedLongDate��   
FormatTime$ 
@ShortTime��  $��Right=�   DateTimeMode$ TimeOnly=�$��14(����	#FFFFFFFF$��Segoe UI)�$
��Bold"�$��0,24,8,0q�$��151.5��$��24��$	��Top=�$��Right=�$��Center=��� $��	0,6,450,0q�$	��Top=� �� Orientation$ 
Horizontal=�$��Center=�.+�!  VisiWin.Controls.TextVarOut  -     Name$
 CPU1�� J� Opacity$ 1Q�$��35��$	��200��$��0,0,0,0q�#���  ���	#FFFFFFFF*  $VisiWin.Controls.VariableBaseControl   TextAlignment$ Center=�$��Normal"�$��14(�   Value$ M1 : CPU - 1��  -   $
 CPU2��$ 1Q�$��35��$	��200��$��10,0,0,0q�#���  ���	#FFFFFFFF$ Center=�$��Normal"�$��14(�$ M1 : CPU - 2��  -   $
 CPU3��$y�Hidden=�$ 1Q�$��35��$	��200��$��10,0,0,0q�#���  ���	#FFFFFFFF$ Center=�$��Normal"�$��14(�$ M2 : CPU - 1��  -	   $
 CPU4��$y�Hidden=�$ 1Q�$��35��$	��200��$��10,0,0,0q�#���  ���	#FFFFFFFF$ Center=�$��Normal"�$��14(�$ M2 : CPU - 2��