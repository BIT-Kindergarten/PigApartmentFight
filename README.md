# PigApartmentFight
2020小学期课题作业

选题：游戏过程内容生成算法设计与实现

组员：LK DYT WYF CJT



### 设计

​	游戏世界为Z、X轴所在平面，地面为草地、沙地等，周围由山峰、岩石围绕而成。

​	每一关总共3个怪，玩家与最后一个怪物处于对角线位置，另外两个怪物由第一个怪物复制并随机出现在另外两个方位上的区域中。

​	从起点产生随机路径依次到达每一个怪物（一定范围之内）

​	在地图上随机产生植被、岩石等环境元素。

​	



1. **路径-CJT**

在平面中，起点和终点之间存在一个平行于坐标轴的矩形，且两点处于对角。我们的路径可以首先沿着对角线的方向走，在碰到边界而又没有到达终点范围时，走一次碰撞方向的反方向，并再次趋近终点，反复尝试直到到达终点。

![草地路径1](https://github.com/BIT-Kindergarten/PigApartmentFight/blob/master/mdres/Snipaste_2020-09-20_16-51-44.png)

![草地路径1](https://github.com/BIT-Kindergarten/PigApartmentFight/blob/master/mdres/Snipaste_2020-09-20_16-52-01.png)



2. **植被、石头**

两种方案：

​		1.调试（Debug.Log）出一个路径不会通过的大概区域，在区域内放置对象；

​		2. 生成路径时记录每一块地板的位置，标记为false。路径完成之后，遍历每一块地板并在附近标记为true的地方放置对象。

![草地植被1](https://github.com/BIT-Kindergarten/PigApartmentFight/blob/master/mdres/Snipaste_2020-09-20_16-50-28.png)

![草地植被1](https://github.com/BIT-Kindergarten/PigApartmentFight/blob/master/mdres/Snipaste_2020-09-20_16-50-43.png)

B站演示视频:https://b23.tv/8JJouf
