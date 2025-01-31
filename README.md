# 模拟经营加生存建造类游戏 - 系统设计

## 村民属性

每个村民有以下基本属性: 

- **名字**: 村民的名字.
- **年龄**(天数) : 村民的当前年龄(以天数为单位) .
- **体力上限**: 村民的最大体力值.
- **当前体力**: 村民当前的体力值.
- **每日所需食物**: 村民每天消耗的食物数量.
- **护甲值**: 村民穿戴护甲后增加的防御值.
- **是否成年**: 村民是否成年, 成年后才可从事资源开采或战斗任务.
- **职业**: 村民的职业, 根据装备的工具或武器决定.
- **当前的武器/工具**: 村民当前使用的武器或工具.
- **当前的护甲**: 村民穿戴的护甲或衣服.

## 村民成长与职业

### 幼年村民
- 体力上限: 5
- 每日所需食物: 1
- 无法装备护甲或武器
- 无法应用职业

### 成年村民
- 当村民年龄达到 3 天时, 村民会成年, 并切换为成年村民的精灵图像.
- 成年后可以装备武器和护甲.
- 可以从事各种任务并改变职业.

### 职业变化
- **基础村民**: 未装备武器时, 职业为村民, 只能做基础工作(如采摘、拾取等) .
- **弓箭手**: 装备弓后, 职业变为弓箭手, 可以进入箭塔工作, 射击敌人或生物.
- **农夫**: 装备锄头后, 职业变为农夫, 可以在农场工作, 农场可以产出食物.
- **矿工**: 装备稿子后, 职业变为矿工, 可以在矿场工作, 矿场可以产出矿石等.
- **其他职业**: 包括战士、铁匠、伐木工等, 可根据所装备的武器或工具变换职业, 且可以扩展.

## 护甲与武器系统

### 护甲
- 每件护甲(衣服) 都有护甲点数, 用于在战斗时计算伤害减免.
- 护甲不会影响村民的职业, 但会对特定职业在工作场景中产生加成效果.
  - **例如**: 
    - **弓箭手轻甲**: 增加弓箭手在射箭时的射速.
    - **粗布麻衣**: 增加农夫在农场工作的食物产出速度.

### 武器和工具
- 武器和工具有不同的材料属性, 材料越好, 武器和工具的加成效果越强.
- 武器和工具的类型决定村民的职业, 如弓、锄头等.

## 村民装备与信息管理

- 点击村民的身体会弹出界面, 显示以下信息: 
  - 体力、年龄等基本信息.
  - 装备槽: 允许拖动现有的武器或护甲装备到村民的装备栏.
  - 护甲槽: 用于穿戴护甲/衣服, 并改变村民的防御属性.
- 通过装备不同的武器或护甲, 可以更改村民的职业, 并增强其在特定任务中的效率.

## 建筑系统

- 通过点击 UI 按钮并选择所需的建筑类型, 玩家可以消耗材料(如食物、木材、石头、矿物等) 在场景中建造建筑.
  - **建筑类型**: 
    - **矿场**: 产出矿石.
    - **农场**: 产出食物.
    - **棚屋**: 提供村民住宿.
    - **仓库**: 存储物资.
- 建筑可以升级, 提升产出效率或存储空间.

## 食物系统与生存机制

- 游戏每天(一个日夜循环) 会结算一次食物储备.
  - 根据每个村民的食物需求量, 扣除相应的食物.
  - 如果食物储备不足, 未能满足食物需求的村民将死亡.
