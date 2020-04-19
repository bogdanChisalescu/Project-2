clear all;
close all;
clc;

%Prima masuratoare efectuata asupra senzorului
%de nivel al apei
Dif = 3;
Hvas = [ 5 9 14 18 24 28 33 37 39 41 45];
Hs = Hvas - Dif;
Vout = [ 2.28 2.38 2.5 2.58 2.63 2.68 2.73 2.85 2.88 2.96 3.28];
figure(1), plot(Hs, Vout, 'o')
title('Prima masuratoare de etalonare - senzor de nivel al apei'), 
xlabel('Inaltimea coloanei de apa [mm]'), ylabel('Tensiunea de iesire [V]')