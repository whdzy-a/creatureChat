## Language
- [English](#english)
- [中文](#中文)

---
### 中文
### **介绍** 

本教程将指导您如何通过修改`pup.json`来扩展猫崽对话内容。这个文件定义了Slugpup在不同状态和个性倾向下的对话文本。你可以通过添加新的对话或修改现有内容来丰富游戏体验。

---

### **文件位置** 

`pup.json`在模组文件夹的`Puptxt\pup.json`

例：`D:\Program Files\steam\steamapps\workshop\content\312520\3626655084\PupText\pup.json`

当游戏从暂停中恢复时，模组将会读取json文件的内容并将读取到的对话输出到游戏根目录的`AllDialogues.txt`

---

### **文件结构** 

`pup.json`文件包含三个模块：**`性格`**、**`状态`**、**`对话`**

- **`性格`** 这是最外层的大类，虽然一开始只以性格作为分类依据，但是随着一些想法的革新，性格已经不仅仅只有性格，现在它已经是一个复合型的检索方式，目前游戏内猫崽使用的对话为Defualt（猫崽对话的主体）+ 性格（使用猫崽最突出的性格）+ 猫崽类型（如溪流崽）。虽然猫崽类型相关的对话还没写出来，但是很快了。

- **`状态`** 这是文件的二级分类，写在`性格`之内，用来表明性格之下的状态（如要求停留，背起，玩耍，捡起某些东西，即将下雨，被某些生物抓住，没某些生物杀死）。有些状态甚至支持对特定物品或者生物起作用，例如（`Carch by Lizard`就是表明被蜥蜴抓住，而`Catch`则表明被抓住，若当前抓住猫崽的生物没有对应的状态可用，那么将会退回到最基础的`Catch`）

- **`对话`** 这是文件的末端，写在`状态`之内作为此状态的随机候选词，特殊写法可参照这个：https://github.com/whdzy-a/creatureChat

---

### **如何添加或修改对话** 

如果你只想修改原有的对话请跳到第四条

### 1. 添加性格 

添加性格只需要在`pup.json`(以下简称文件)的最外层添加一个新的objcet，其key为性格或猫的特殊种类

例（此处例为活力）：
```json
"vitality": {
}
```

例2(此处例为白猫)：
```json
"White": {
}
```

### 2. 添加状态 

接下来在这个性格之下添加状态，可用的状态可见下表
状态分为普通的状态和带关键词的状态，带关键词的状态往往都有无关键词的版本
例（活力性格下的被杀死、被蜥蜴杀死、和捡起矛）：
```json
"vitality": {
    "Kill": [],
    "Kill by Lizard": [],
    "Grab Spear": []
}
```

### 3. 添加对话 

接下来我们需要在每个状态下都添加对话

例：
```json
"vitality": {
    "Kill": [
        "I am die",
        "Oh on!",
        "What can I say?"
    ],
    "Kill by Lizard": [
        "I was killed by Lizard!",
        "I also Killed by Lizard!",
        "I aallssoo killed by Lizards!"
    ],
    "Grab Spear": [
        "I grab a spear!",
        "I have a spear!",
        "I catch a spear!"
    ]
}
```

### 4. 修改状态 

假设我想修改`aggression`下的`Grab Spear`

原本的`Grab spear`是这样的：
```json
"Grab Spear": [
    "I found the weapon!",
    "A handy weapon.",
    "Find me a target.",
    "Now I can clear the threat for you.",
    "I can drive them away for you!",
    "Now I have combat capability!",
    "I like this, it makes me feel no longer weak.",
    "These are my sharp teeth.",
    "The weapon I trust the most.",
    "Great, a weapon!",
    "Battle? Yeah!"
]
```

整个改成`Grab ScavengerBomb`行不行？当然可以了！

下面是修改后的：
```json
"Grab ScavengerBomb": [
    "I found the weapon!",
    "A handy weapon.",
    "Find me a target.",
    "Now I can clear the threat for you.",
    "I can drive them away for you!",
    "Now I have combat capability!",
    "I like this, it makes me feel no longer weak.",
    "These are my sharp teeth.",
    "The weapon I trust the most.",
    "Great, a weapon!",
    "Battle? Yeah!"
]
```

### 5. 修改对话 

假如有某句话冒犯到你了，或者你希望添加一句有意思的话，再或者你想修改几个字符，甚至！你认为目前的对话根本就不是猫崽应该有的语气，你希望完全重构一个不是人类思想拉出来的对话！

完全没问题！你只需要直接修改你想修改的那一句话，直接整句删除，或者直接在这个状态下增加新的一句话。

特别要注意的是，整个文件一定要符合json的要求，可以在第三方的json检查网站检查。

假设我不喜欢那一句`"I'm a little scared...<NEXT>Please come back quickly..."`

首先要找到这句话的位置

例如：
```json
"sympathy": {
    "Waiting": [
        "I'm a little scared...<NEXT>Please come back quickly...",
        ...
    ]
}
```
然后再去修改它

---

**表1：状态总表** 
| 状态键名 | 英文名称 | 描述 | 触发场景 |
|---------|---------|------|----------|
| `Waiting` | Waiting | 等待状态 | 玩家命令猫崽在原地等待 |
| `Following` | Following | 跟随状态 | 猫崽开始跟随玩家时 |
| `Onback` | On Back | 在背上 | 玩家背起猫崽 |
| `Outback` | Out of Back | 离开背部 | 猫崽从玩家背上下来时 |
| `Fleeing` | Fleeing | 逃跑 | 猫崽遇到捕食者逃跑时 |
| `Attacking` | Attacking | 攻击 | 猫崽主动攻击敌人时 |
| `Hurt` | Hurt | 受伤 | 猫崽被任何来源伤害时 |
| `Hurt by {creature}` | Hurt by | 被{生物}伤害时 | 猫崽被设定的生物伤害时 |
| `Catch` | Catch | 被抓住 | 猫崽被除玩家外抓住时 |
| `Catch by {creature}` | Catch by | 被{生物}抓住 | 猫崽被设定的生物抓住时 |
| `Kill` | Kill | 濒死/被杀 | 猫崽死亡时 |
| `Kill by {creature}` | Kill by | 被{生物}杀死 | 猫崽被设定的生物杀死时 |
| `Saved` | Saved | 被救 | 猫崽从危险中被救出 |
| `Saved by {creature}` | Saved by | 被{生物}所救 | 设定的生物救出猫崽时 |
| `Grab {Liked/Neutral/Disliked}` | Grab | 抓住不同态度的食物 | 猫崽捡起不同态度的食物时 |
| `Grab {object}` | Grab | 抓住{物品} | 猫崽捡起设定的物品时 |
| `Save {creature}` | Save | 拯救{生物} | 猫崽救下设定的生物时 |
| `Sleep` | Sleep | 睡觉 | 猫崽进入睡眠时 |
| `Wakeup` | Wakeup | 醒来 | 猫崽醒来时 |
| `Rain` | Rain | 下雨 | 雨即将来临时 |
| `Intoplay` | Into Play | 开始玩耍 | 猫崽自发开始玩耍时 |
| `Intoplay with Slugcat` | Into Play with Slugcat | 与玩家玩耍 | 猫崽与玩家开始互动玩耍时 |
| `Intoplay with Slugpup` | Into Play with Slugpup | 与其他猫崽玩耍 | 猫崽与其他Slugpup开始玩耍时 |
| `Playing` | Playing | 玩耍中 | 猫崽独自玩耍时 |
| `Playing with Slugcat` | Playing with Slugcat | 与玩家玩耍中 | 猫崽与玩家玩耍过程中 |
| `Playing with Slugpup` | Playing with Slugpup | 与其他猫崽玩耍中 | 猫崽与其他Slugpup玩耍过程中 |
| `Outplay` | Out of Play | 结束玩耍 | 猫崽停止玩耍时 |
| `Rest` | Rest | 休息 | 猫崽短暂休息时（非睡觉） |

---

**表2：带关键词的状态** 
| 状态键名 | 英文名称 | 描述 | 触发场景 |
|---------|---------|------|----------|
| `Hurt by {creature}` | Hurt by | 被{生物}伤害时 | 猫崽被设定的生物伤害时 |
| `Catch by {creature}` | Catch by | 被{生物}抓住 | 猫崽被设定的生物抓住时 |
| `Kill by {creature}` | Kill by | 被{生物}杀死 | 猫崽被设定的生物杀死时 |
| `Saved by {creature}` | Saved by | 被{生物}所救 | 设定的生物救出猫崽时 |
| `Grab {Liked/Neutral/Disliked}` | Grab | 抓住不同态度的食物 | 猫崽捡起不同态度的食物时 |
| `Grab {object}` | Grab | 抓住{物品} | 猫崽捡起设定的物品时 |
| `Save {creature}` | Save | 拯救{生物} | 猫崽救下设定的生物时 |

---

**表3：CreatureChat的特殊规则** 
| Tag | Function | Example |
|-----|----------|---------|
| `<LINE>` | Line break in text | `"First line<LINE>Second line"` |
| `<NEXT>` | Separate dialogue segments | `"Segment 1<NEXT>Segment 2"` |
| `<color#rrggbbaa>` `<colorend>` | Change the color of the text | `<color#ff0000ff>This text will turn red<colorend>` |
| `<shakeShakeIntensite>` `<shakeend>` | Make the text shake | `<shake1>This text will shake into 1 pixel<shakeend>` |
| `<waveWaveIntensite>` `<Waveend>` | Make the text wave | `<waveWave3>This text will wave into 3 pixel<Waveend>` |
| `<rainbowSpeed>` `<rainbowend>` | Change the color of the text according to the Speed(The speed can be in the negative direction) | `<rainbow0.05>Rainbow!</rainbowend>` |
More text-related features are in the planning stages!

---

如果你需要我帮你编写某个特定状态或性格的对话扩展，或需要更具体的示例，请告诉我！



---
### English
# creatureChat
A Rainworld mod that can create a dialog box that follows any item.

## Quick Start

### Basic Dialogue
This class can be created anywhere, and once it is created, it will automatically operate,This is the simplest example:

```csharp
new CreatureChatTx(
    room,           // Current room
    0,              // Frames to wait before starting
    player,         // Speaking character, if this is null, the dialogue will show in the buttom of the screen
    "I'm a slugpup,meow!"  // Dialogue content
);
```

### Multi-part Dialogue
Use <NEXT> to separate multiple dialogue segments:

```csharp
new CreatureChatTx(
    room,           // Current room
    0,              // Frames to wait before starting
    player,         // Speaking character
    "I'm a slugpup,meow!<NEXT>I said, meow!"  // Dialogue content
);
```

### Dialogue with Screen Prompts

```csharp
new CreatureChatTx(room, 0, player, "I'm a slugpup,meow!",
    textprompt: "Screen prompt text",    // Text displayed at bottom of screen
    textPromptWait: 10,                  // Prompt wait time
    textPromptTime: 320);                // Prompt display duration
```

### Interruptible Dialogue

```csharp
new CreatureChatTx(room, 0, player, "Dialogue content",
    canInterruptedByStun: true,   // Interrupt when stunned
    canInterruptedByDead: true);  // Interrupt when dead
```

## Text Formatting

| Tag | Function | Example |
|-----|----------|---------|
| `<LINE>` | Line break in text | `"First line<LINE>Second line"` |
| `<NEXT>` | Separate dialogue segments | `"Segment 1<NEXT>Segment 2"` |****
| `<color#rrggbbaa>` `<colorend>` |Change the color of the text| `<color#ff0000ff>This text will turn red<colorend>` |
| `<shakeShakeIntensite>` `<shakeend>` |Make the text shake| `<shake1>This text will shake into 1 pixel<shakeend>` |
| `<waveWaveIntensite>` `<Waveend>` |Make the text wave| `<waveWave3>This text will wave into 3 pixel<Waveend>` |
| `<rainbowSpeed>` `<rainbowend>` |Change the color of the text according to the Speed(The speed can be in the negative direction)| `<rainbow0.05>Rainbow!</rainbowend>` |
More text-related features are in the planning stages!

## Parameter Reference

| Parameter | Type | Description |
|-----------|------|-------------|
| `room` | `Room` | Current game room |
| `preWaitCounter` | `int` | Frames to wait before dialogue starts |
| `chatter` | `Player` | Speaking character |
| `talkText` | `string` | Dialogue content |
| `canInterruptedByStun` | `bool` | Whether to interrupt when stunned |
| `canInterruptedByDead` | `bool` | Whether to interrupt when dead |
| `textprompt` | `string` | Screen prompt text |
| `textPromptWait` | `int` | Prompt wait time |
| `textPromptTime` | `int` | Prompt display duration |

