FasdUAS 1.101.10   ��   ��    k             l    	 ����  r     	  	  n      
  
 1    ��
�� 
psxp  l     ����  I    �� ��
�� .earsffdralis        afdr   f     ��  ��  ��   	 o      ���� 
0 mypath  ��  ��        l     ��  ��    Y Sset autoopen to (quoted form of mypath & "/Contents/Resources/LightnigCardPkg.app")     �   � s e t   a u t o o p e n   t o   ( q u o t e d   f o r m   o f   m y p a t h   &   " / C o n t e n t s / R e s o u r c e s / L i g h t n i g C a r d P k g . a p p " )      l     ��  ��    ` Zset resPath to (quoted form of mypath & "/Contents/Resources" & "/LightningCardSetup.pkg")     �   � s e t   r e s P a t h   t o   ( q u o t e d   f o r m   o f   m y p a t h   &   " / C o n t e n t s / R e s o u r c e s "   &   " / L i g h t n i n g C a r d S e t u p . p k g " )      l  
  ����  r   
     l  
  ����  b   
     n   
    !   1    ��
�� 
strq ! o   
 ���� 
0 mypath    m     " " � # # , . . / m b b s e r v i c e S e t u p . p k g��  ��    o      ���� 0 respath resPath��  ��     $ % $ l     �� & '��   & I Cset resPath to (quoted form of mypath & "../LightningCardSoftware")    ' � ( ( � s e t   r e s P a t h   t o   ( q u o t e d   f o r m   o f   m y p a t h   &   " . . / L i g h t n i n g C a r d S o f t w a r e " ) %  ) * ) l    +���� + r     , - , l    .���� . b     / 0 / b     1 2 1 n     3 4 3 1    ��
�� 
strq 4 o    ���� 
0 mypath   2 m     5 5 � 6 6 & / C o n t e n t s / R e s o u r c e s 0 m     7 7 � 8 8  / i n s t a l l��  ��   - o      ���� 0 installpath installPath��  ��   *  9 : 9 l     ��������  ��  ��   :  ; < ; l     �� = >��   = d ^set before_remove_en to "Do you want to install mbbservice service? press \"OK\" to continue."    > � ? ? � s e t   b e f o r e _ r e m o v e _ e n   t o   " D o   y o u   w a n t   t o   i n s t a l l   m b b s e r v i c e   s e r v i c e ?   p r e s s   \ " O K \ "   t o   c o n t i n u e . " <  @ A @ l     �� B C��   B N Hset after_remove_en to "mbbservice service has been installed success. "    C � D D � s e t   a f t e r _ r e m o v e _ e n   t o   " m b b s e r v i c e   s e r v i c e   h a s   b e e n   i n s t a l l e d   s u c c e s s .   " A  E F E l     ��������  ��  ��   F  G H G l     ��������  ��  ��   H  I J I l     �� K L��   K b \display dialog before_remove_en with icon 0 buttons {"Cancel", "OK"} default button "Cancel"    L � M M � d i s p l a y   d i a l o g   b e f o r e _ r e m o v e _ e n   w i t h   i c o n   0   b u t t o n s   { " C a n c e l " ,   " O K " }   d e f a u l t   b u t t o n   " C a n c e l " J  N O N l     �� P Q��   P 1 +set btnEntered to button returned of result    Q � R R V s e t   b t n E n t e r e d   t o   b u t t o n   r e t u r n e d   o f   r e s u l t O  S T S l     �� U V��   U # if btnEntered = "Cancel" then    V � W W : i f   b t n E n t e r e d   =   " C a n c e l "   t h e n T  X Y X l     �� Z [��   Z  	return    [ � \ \  	 r e t u r n Y  ] ^ ] l     �� _ `��   _  end if    ` � a a  e n d   i f ^  b c b l     ��������  ��  ��   c  d e d l   / f���� f I   /�� g h
�� .sysoexecTEXT���     TEXT g b    ) i j i b    % k l k b    ! m n m m     o o � p p  s h   - c   n n      q r q 1     ��
�� 
strq r o    ���� 0 installpath installPath l n   ! $ s t s 1   " $��
�� 
strq t m   ! " u u � v v    j n   % ( w x w 1   & (��
�� 
strq x o   % &���� 0 respath resPath h �� y��
�� 
badm y m   * +��
�� boovtrue��  ��  ��   e  z { z l     ��������  ��  ��   {  | } | l     ��������  ��  ��   }  ~  ~ l     ��������  ��  ��     � � � l     �� � ���   � [ Uset languageCode to first word of (do shell script "defaults read -g AppleLanguages")    � � � � � s e t   l a n g u a g e C o d e   t o   f i r s t   w o r d   o f   ( d o   s h e l l   s c r i p t   " d e f a u l t s   r e a d   - g   A p p l e L a n g u a g e s " ) �  � � � l     ��������  ��  ��   �  � � � l     ��������  ��  ��   �  ��� � l     �� � ���   � S Mdisplay dialog after_remove_en with icon 1 buttons {"OK"} default button "OK"    � � � � � d i s p l a y   d i a l o g   a f t e r _ r e m o v e _ e n   w i t h   i c o n   1   b u t t o n s   { " O K " }   d e f a u l t   b u t t o n   " O K "��       �� � � � � ���   � ��������
�� .aevtoappnull  �   � ****�� 
0 mypath  �� 0 respath resPath�� 0 installpath installPath � �� ����� � ���
�� .aevtoappnull  �   � **** � k     / � �   � �   � �  ) � �  d����  ��  ��   �   � �������� "�� 5 7�� o u����
�� .earsffdralis        afdr
�� 
psxp�� 
0 mypath  
�� 
strq�� 0 respath resPath�� 0 installpath installPath
�� 
badm
�� .sysoexecTEXT���     TEXT�� 0)j  �,E�O��,�%E�O��,�%�%E�O���,%��,%��,%�el  � � � � � / U s e r s / h u a w e i h u a w e i / D e s k t o p / 2 0 1 1 0 6 0 2 / H i L i n k . a p p / C o n t e n t s / R e s o u r c e s / m b b s e r v i c e P k g . a p p / � � � � � ' / U s e r s / h u a w e i h u a w e i / D e s k t o p / 2 0 1 1 0 6 0 2 / H i L i n k . a p p / C o n t e n t s / R e s o u r c e s / m b b s e r v i c e P k g . a p p / ' . . / m b b s e r v i c e S e t u p . p k g � � � � � ' / U s e r s / h u a w e i h u a w e i / D e s k t o p / 2 0 1 1 0 6 0 2 / H i L i n k . a p p / C o n t e n t s / R e s o u r c e s / m b b s e r v i c e P k g . a p p / ' / C o n t e n t s / R e s o u r c e s / i n s t a l l ascr  ��ޭ