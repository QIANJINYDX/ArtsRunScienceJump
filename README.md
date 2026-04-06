# ArtsRunScienceJump

基于 **Unity** 的 2D 跑酷类小游戏，2020 年暑假学习/开发记录。仓库内包含学习笔记（含截图与代码片段）以及 `Sprits/` 目录下的 C# 脚本实现。

## 项目简介

- **类型**：跑酷 / 平台跳跃
- **背景**：暑期 Unity 学习与练手项目
- **引擎**：Unity（笔记中场景、UI、物理均按 Unity 工作流描述）

## 操作说明

| 按键 | 作用 |
|------|------|
| `A` / `D` | 左右移动 |
| `Space` | 跳跃（需接触地面 `ground` 标签） |
| `U` / `I` / `J` / `K` | 在允许时调整角色局部缩放（X/Y 增减） |
| `O` | 重置缩放 |
| `Esc` | 显示暂停/返回类 UI（配合 `CanvasGroup`） |
| `P` | 隐藏上述 UI |

通关、碰撞门体等逻辑见各脚本与笔记。

## 功能概览

- **主菜单与关卡 UI**：简单方块风格 UI；横向可滑动关卡列表，松手后吸附到最近一页，并与底部 Toggle 联动（`Myscrollguanqia`）。
- **场景切换**：按钮挂载脚本，通过 `SceneManager.LoadScene` 按场景编号加载（`场景切换`）。
- **角色**：刚体移动、跳跃、地面/门碰撞检测、跌落销毁、可选变形（`Player`）。
- **暂停与结算**：`ESC_KK` 用 `CanvasGroup` 控制显隐与交互；到达终点门时弹出胜利界面并 `Time.timeScale = 0`（笔记中写在门碰撞逻辑里）。
- **计时**：使用 `Time.timeSinceLevelLoad` 显示本关用时（暂停时不刷新显示）。
- **关卡进度**：`PlayerPrefs` 存储 `levelReached`，关卡选择界面根据进度启用/禁用按钮（`LevelSelect`；原笔记中实现可能存在逻辑问题，需对照需求自查）。
- **机关与玩法**：左右往返移动平台（`LeftRightMove`）、尖刺碰撞结束、周期发射子弹的炮台（`Shoot`）、踩海绵获得向上速度等。

## 脚本目录（`Sprits/`）

| 脚本 | 说明 |
|------|------|
| `场景切换.cs` | 按索引加载场景 |
| `Myscrollguanqia.cs` | ScrollRect 分页滑动与 Toggle 同步 |
| `Player.cs` | 玩家移动、跳跃、碰撞与缩放 |
| `ESC_KK.cs` | Esc / P 控制覆盖层 UI |
| `Door.cs` | 与玩家碰撞后的通关 UI / 暂停（见笔记） |
| `LevelSelect.cs` | 关卡按钮与 `PlayerPrefs` |
| `LeftRightMove.cs` | 限定范围内左右往返移动 |
| `Shoot.cs` | 按间隔实例化子弹并赋予初速度 |
| `MoveJump.cs`、`CameraController.cs`、`ChangeMusic.cs` 等 | 移动跳跃变体、相机、音乐等扩展 |

（目录名 `Sprits` 为历史拼写，与 Unity 中常见的 `Scripts` 对应。）

## 开发文档配图

### 第一天：UI 与首场景

**简单方形风格 UI**

![简单方形风格主界面](https://img-blog.csdnimg.cn/20200711221822468.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**可滑动关卡列表**

![可滑动关卡列表](https://img-blog.csdnimg.cn/20200711221909948.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**第一个游戏场景**

![第一个游戏场景](https://img-blog.csdnimg.cn/2020071122195875.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**场景切换：按钮 OnClick 与场景编号设置**

![场景切换按钮 Inspector 设置](https://img-blog.csdnimg.cn/20200711222207831.png)

### 第二天：暂停 UI、通关与计时

**返回/暂停相关 UI 布局**

![暂停返回 UI 画面](https://img-blog.csdnimg.cn/20200712094355157.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**覆盖层挂载 Canvas Group（Alpha / Interactable）**

![Canvas Group 组件设置](https://img-blog.csdnimg.cn/20200712094426300.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**ESC_KK 脚本挂载**

![ESC_KK 脚本挂载](https://img-blog.csdnimg.cn/20200712094552364.png)

**通关 / 游戏结束界面**

![通关或结束界面 UI](https://img-blog.csdnimg.cn/20200712095003446.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**计时用 Text UI**

![计时文本 UI](https://img-blog.csdnimg.cn/20200712224853967.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**Player 脚本绑定显示时间的 Text**

![Player 绑定 time_text](https://img-blog.csdnimg.cn/20200712224558934.png)

### 第三至四天：炮台与关卡预览

**Shoot 炮台：子弹预制体与发射点等 Inspector**

![Shoot 炮台 Inspector](https://img-blog.csdnimg.cn/20200715212935887.png)

**第三关**

![第三关关卡画面](https://img-blog.csdnimg.cn/20200715213132133.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

**第四关**

![第四关关卡画面](https://img-blog.csdnimg.cn/20200715213145284.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

## 使用说明

1. 在 Unity 中创建或打开对应工程，将 `Sprits/` 中脚本挂到相应物体或 UI 上。
2. 按各笔记中的标签（如 `ground`、`Door`、`haimian`）与组件要求配置场景。
3. 在 **Build Settings** 中注册场景并保证 `场景切换` 使用的索引与场景顺序一致。

---