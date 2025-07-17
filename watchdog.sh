#!/bin/sh

tmp_path=`pwd`
CUR_PATH=$(dirname $(readlink -f $0))
cd $CUR_PATH

rm *.pdb
rm *.mdb
rm *.xml

cd $tmp_path

rm ~/Desktop/watchdog.desktop
rm ~/桌面/watchdog.desktop

rm WatchDog
mkbundle -o WatchDog WatchDog.exe --i18n none --simple --nodeps -v

cat > ~/Desktop/watchdog.desktop <<EOF
[Desktop Entry]
Encoding=UTF-8
Name=五防控制台
Exec=bash -c 'cd $CUR_PATH && $CUR_PATH/WatchDog'
Icon=$CUR_PATH/content/watchdog.png
Terminal=falsemkbundle -o WatchDog WatchDog.exe --i18n none --simple --nodeps -v
Type=Application
EOF

cat > ~/桌面/watchdog.desktop <<EOF
[Desktop Entry]
Encoding=UTF-8
Name=五防控制台
Exec=bash -c 'cd $CUR_PATH && $CUR_PATH/WatchDog'
Icon=$CUR_PATH/content/watchdog.png
Terminal=false
Type=Application
EOF

chmod +x ~/Desktop/watchdog.desktop
chmod +x ~/桌面/watchdog.desktop
