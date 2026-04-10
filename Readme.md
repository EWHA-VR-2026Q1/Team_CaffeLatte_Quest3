# Assignment 09
## Team. CaffeLatte
### 팀장: 2466026 백재은
### 팀원: 2376034 김민주
### 팀원: 2376218 이유진
### 팀원: 2371030 민지인
-------
## Purpose of this Project
### Topic: 현실의 확장
### Logic: 물리법칙
자연현실에서는 중력, 탄성, 관성, 작용/반작용 등의 물리 법칙이 고정되어 있어 변경하거나 비교 체험할 수 없다. 본 프로젝트는 VR 환경(Meta Quest 3)에서 이러한 물리 법칙의 조건을 자유롭게 변경하고 그 결과를 신체적으로 체험할 수 있는 "물리법칙 Living Lab"을 구현하였다. 사용자는 각 실험실에서 중력의 크기, 탄성 계수, 질량에 따른 관성, 힘의 작용/반작용을 직접 조작하며, 자연현실에서는 불가능한 물리 조건의 비교 실험을 수행할 수 있다. 이를 통해 "가상현실이 자연현실의 물리적 한계를 넘어서는 확장된 현실이 될 수 있는가"를 실험한다.

## Directory of this Project
```
Assets/
├── HW_09/
│   ├── Action_Room/
│   │   ├── Materials/
│   │   ├── Prefabs/
│   │   ├── Scenes/
│   │   ├── Scripts/
│   │   └── Texture/
│   ├── Elastic_Room/
│   │   ├── Materials/
│   │   ├── Prefabs/
│   │   ├── Scenes/
│   │   └── Scripts/
│   ├── Gravity_Room/
│   │   ├── Material/
│   │   ├── Prefab/
│   │   ├── Scenes/
│   │   ├── Scripts/
│   │   └── Texture/
│   ├── Inertia_Room/
│   │   ├── Materials/
│   │   ├── Prefabs/
│   │   ├── Scenes/
│   │   └── Scripts/
│   ├── Main_Room/
│   │   ├── Materials/
│   │   ├── Media/
│   │   ├── Prefabs/
│   │   ├── Scenes/
│   │   ├── Scripts/
│   │   └── Texture/
│   ├── Prefab/
│   └── Scripts/
│       ├── EX_CharacterController/
│       ├── EX_Events_Controls/
│       └── EX_OVRInput/
├── Oculus/
├── Plugins/
├── QuickOutline/
├── Resources/
├── Scenes/
├── StreamingAssets/
├── TextMesh Pro/
├── XR/
└── YughuesFreeConcreteeMaterials/
```

--------------------
## Main_Room
Made by Jaeeun Baek
### 1. Purpose of this Scene
각 물리 실험실(Action, Elastic, Gravity, Inertia)로 이동할 수 있는 로비 씬. 4개의 문에 Sign_Action, Sign_Gravity, Sign_Inertia, Sign_Elastic 표지판이 부착되어 있으며, 사용자는 원하는 실험실을 선택하여 진입할 수 있다. 메인 씬에서 모든 실험실 씬을 로딩할 수 있고, 각 실험실에서 다시 메인 씬으로 복귀할 수 있다.

### 2. Key Logic
- `D05_LoadScene.cs`: 플레이어가 문의 트리거 영역에 진입하면 지정된 씬으로 자동 전환

### 3. How to run this Scene
- Enter: 앱 실행 시 최초 진입 씬
- Control:
	- 오른손 컨트롤러의 조이스틱으로 이동하여 원하는 실험실 문 앞의 트리거 영역에 진입 -> 자동으로 해당 실험실 씬으로 전환

### 4. Directory of this Scene
```
Scene_Main
├── Environment/
│   ├── Room/ (Ground, Walls, Cilling)
│   ├── Portal/
│   │   ├── Door_Action/
│   │   ├── Door_Gravity/
│   │   ├── Door_Elastic/
│   │   └── Door_Intertia/
│   └── Lighting/
├── Player/
│   └── Player_OVRInput_Parts_V2
└── Sign_Action, Sign_Gravity, Sign_Inertia, Sign_Elastic
```

--------------------
## Action_Room
Made by Jaeeun Baek
### 1. Purpose of this Scene
작용/반작용(뉴턴 제3법칙)을 체험하는 씬. 자연현실에서는 반작용을 의식하기 어렵지만, VR에서는 블록을 밀 때 자신이 밀려나는 경험, 대포 발사 시 반동으로 밀려나는 경험을 통해 작용/반작용이 동시에 발생하는 물리 법칙을 신체적으로 체감할 수 있다. 이는 자연현실에서는 느끼기 어려운 힘의 상호작용을 확장된 방식으로 체험하는 것이다.

### 2. Key Logic
- `PushReaction.cs` + `PushTriggerZone.cs`: Right Controller의 A 버튼으로 블록을 밀면 블록에 Impulse가 가해지고, 플레이어에게 반대 방향 knockback 적용
- `CannonLauncher.cs`: Right Controller의 B 버튼으로 대포 발사 시 포탄에 힘이 가해지고, 플레이어에게 반동(recoil) 적용
- `PlayerKnockback.cs`: CharacterController 기반으로 knockback 속도를 감쇠시키며 적용

### 3. How to run this Scene
- Enter: Main_Room에서 Action 문을 통해 진입
- Control:
	- Experiment 1: Exp_PushWall 영역에서 A 버튼 -> 블록을 밀고 플레이어가 반대로 밀려남 (작용/반작용)
	- Experiment 2: Exp_Launcher 영역에서 B 버튼 -> 대포 발사 및 플레이어에게 반동 발생 (작용/반작용)
- Exit: Door를 통해 Main_Room으로 복귀

### 4. Directory of this Scene
```
Scene_Action
├── Environment/
│   ├── Room/ (Ground, Walls, Cilling)
│   └── Experiments/
│       ├── Exp_PushWall/ (PushWall, TriggerZone, press_A)
│       └── Exp_Launcher/ (Cannon, LaunchPoint, press_B)
├── Lighting/ (Lamp_Launch, Lamp_Wall)
├── Player/
│   └── Player_OVRInput_Parts_V2
├── Exit/
└── Door/
```

--------------------
## Inertia_Room
Made by Jeein Min
### 1. Purpose of this Scene
관성(Inertia)을 체험하는 씬. 사용자는 공을 밀거나 던지며 관성 법칙이 깨진 세계를 경험할 수 있다.

### 2. Key Logic
- `RayPushBall.cs`: 레이 클릭 시 작은 공에 Impulse를 가하여 밀어냄. 이 때 작은 공은 사용자가 레이를 쏜 반대 방향으로 굴러감
- `StopOnWallBall.cs`: 큰 공이 벽에 부딪히면 즉시 정지 후 멈춤

### 3. How to run this Scene
- Enter: Main_Room에서 Inertia 문을 통해 진입
- Control:
	- Experiment 1: SmallReverseBall에 LIndexTrigger로 (왼손 위 버튼) 레이 클릭 → 작은 공이 반대 방향으로 밀려남 (틀린 관성)
	- Experiment 2: HeavyStopBall에 LHandTrigger로 (왼손 안쪽 버튼) grap하여 던짐  → 큰 공이 벽에 닿자마자 즉시 정지함 (사라진 관성)
- Exit: Door를 통해 Main_Room으로 복귀

### 4. Directory of this Scene
```
Scene_Inertia
├── Environment/
│   ├── Room/ (Ground, Walls, Cilling)
│   └── Experiments/
│       ├── SmallReverseBall1
│       ├── SmallReverseBall2
│       └── HeavyStopBall
├── Lights/ (Directional Light, Lamp_Launch)
├── Player_OVRInput_Parts_V2
├── Exit/
├── Door/
└── SceneInitializer
```
--------------------
## Gravity_Room
Made by Minju Kim
### 1. Purpose of this Scene
행성별 중력 차이를 체험하는 씬. 지구, 달, 우주(무중력) 환경에서 공이 떨어지는 속도 차이를 관찰할 수 있다.

### 2. Key Logic
- `GravityPanel.cs`: 패널 클릭 시 Physics.gravity를 해당 행성 값으로 변경하고, 공을 리셋 후 Release
- `BallReset.cs`: 공을 초기 위치로 되돌리고 isKinematic 해제하여 낙하
- `RayForInteraction.cs`: 왼손 트리거로 레이를 발사하여 패널과 상호작용

### 3. How to run this Scene
- Enter: Main_Room에서 Gravity 문을 통해 진입
- Control:
	- Experiment 1: EarthPannel 클릭 → 지구 중력(9.81) 적용, 공 낙하 관찰
	- Experiment 2: MoonPannel 클릭 → 달 중력(1.62) 적용, 공이 천천히 낙하 / SpacePannel 클릭 → 무중력(0) 적용
- Exit: Door를 통해 Main_Room으로 복귀

### 4. Directory of this Scene
```
Scene_Gravity
├── Directional Light
├── Room/ (Lamp, Ground, Walls, Cilling)
├── EarthPannel/ (Earth, Text)
├── MoonPannel/ (Moon, Text)
├── SpacePannel/ (Space, Text)
├── ResetPannel/ (Reset, Text)
├── Ball/ (Text)
├── Player_OVRInput_Parts_V2/ (CameraRig)
├── Exit/
└── Door
```

--------------------
## Elastic_Room
Made by Yujin Lee
### 1. Purpose of this Scene
탄성(Elasticity)을 체험하는 씬. 공의 탄성 계수(Bounciness)를 조절하며 공이 튀는 정도가 달라지는 것을 관찰할 수 있다.

### 2. Key Logic
- `BouncinessController.cs`: PhysicMaterial의 bounciness 값을 0.5 단위로
  증가/감소 (범위 0~1)
- `Door_LoadScene.cs`: Door_ToMain 오브젝트에 연결되어 Main_Room으로 씬 전환


### 3. How to run this Scene
- Enter: Main_Room에서 Elastic 문을 통해 진입
- Control:
  - Experiment 1: 왼손 컨트롤러 Ray로 Button_Up(초록) 클릭
    → 탄성 계수 +0.5 (공이 더 많이 튀어오름)
  - Experiment 2: 왼손 컨트롤러 Ray로 Button_Down(빨강) 클릭
    → 탄성 계수 -0.5 (공이 덜 튀어오름)
- Exit: Door_ToMain을 통해 Main_Room으로 복귀

### 4. Directory of this Scene
```
Scene_Elastic
├── Directional Light
├── Room/
│   ├── Ground/ (Container > Cube)
│   ├── Walls/ (Container > Window, Cube_X-, Cube_X+, Window_vertical, Window_horizontal, Cube_Z+, Cube_Z-)
│   ├── Cilling/ (Container > Cube)
│   ├── Bouncy_Ball (1~4)
│   ├── Door_ToMain
│   ├── Button_Up/ (Label)
│   └── Button_Down/ (Label)
├── Point Light
└── Player_OVRInput_Parts_V2
```
