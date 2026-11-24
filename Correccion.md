# Corrección, Side Scroller 2D (TP07)

- **Alumno/a:** Previtera
- **Entrega:** `TP07_C1_Previtera_CowboyLegend`
- **Materia:** Programación con Motores de Videojuegos I
- **Nota TP07:** 6

## 1. Checklist de requisitos

| #   | Requisito | Estado | Evidencia |
|-----|-----------|--------|-----------|
| R1  | Repositorio nuevo `TP07_C1_Apellido_Titulo` | ✓ | Carpeta `TP07_C1_Previtera_CowboyLegend` con su propio `.git/` (13 commits) |
| R2  | Proyecto de Unity con el mismo nombre | ✓ | `ProjectSettings/ProjectSettings.asset:16` `productName: TP07_C1_Previtera_CowboyLegend`, `TP07_C1_Previtera_CowboyLegend.slnx` |
| R3  | El personaje va a la derecha y a la izquierda | ✓ | `Assets/Scripts/PlayerScripts/PlayerMovement.cs:21` (`GetAxisRaw("Horizontal")`) y `:51` (`linearVelocity` en `FixedUpdate`) |
| R4  | El personaje puede disparar | ✓ | `Assets/Scripts/PlayerScripts/PlayerShoot.cs:26` (tecla J) y `:42` (`Instantiate` de `Bullet.prefab`). Ojo con el Bug: solo dispara hacia la derecha |
| R5  | El personaje puede saltar | ✓ | `Assets/Scripts/PlayerScripts/PlayerJump.cs:15` (Space con `isGrounded`) |
| R6  | Enemigos u obstáculos que quitan vida | ✓ | `Assets/Scripts/EnemyScripts/EnemyShoot.cs:58`, `Assets/Scripts/BulletScripts/EnemyBulletCollision.cs:22` llama a `PlayerLife.TakeDamage` |
| R7  | Se eliminan con más de 2 disparos, tienen vida y barra visible arriba (Canvas World) | Parcial | `Enemy.prefab` tiene `maxHealth: 3` y `EnemyLife.TakeDamage` actualiza la barra. Pero la barra son los objetos `HealthBar` y `Fill` con `SpriteRenderer` escalados en `Assets/Scripts/EnemyScripts/EnemyHealthBar.cs:4`; no hay ningún Canvas en World Space en el proyecto |
| R8  | ParticleSystem al destruir al enemigo | ✓ | `Assets/Scripts/EnemyScripts/EnemyLife.cs:84` instancia `deathParticles` (`Assets/Prefabs/EnemyDeathParticles.prefab`, con `ParticleSystem`) |
| R9  | Hay Pickables | ✓ | `Assets/Scripts/AmmoScripts/AmmoPickUp.cs` (la caja de munición que suelta el enemigo) y `Assets/Scripts/PickablesScripts/HealthPickableScript.cs` con su spawner en `HealthPickableSpawner.cs` |
| R10 | Sonido en todas las acciones | Parcial | Tenés música de gameplay (`AudioManager.cs:42`), salto (`PlayerJump.cs:17`), disparo (`PlayerShoot.cs:37`), muerte de enemigo (`EnemyLife.cs:76`), derrota (`GameManager.cs:20`) y extras (golpe, correr, botones). Te falta el sonido al agarrar un coleccionable: ni `AmmoPickup` ni `HealthPickable` reproducen nada |
| R11 | Volumen configurable desde Settings conectado a un AudioMixer | ✓ | `Assets/Scripts/AudioScripts/SettingsAudio.cs:15` y `:21`, `AudioManager.SetVolume` hace `mixer.SetFloat` sobre `MusicVolume` y `SFXVolume`, expuestos en `Assets/Art/Audio/Master.mixer:65` |
| R12 | Usa ScriptableObject para datos o configuraciones | ✓ | `Assets/Scripts/PlayerScripts/PlayerDataSO.cs`, `Assets/Data/PlayerData.asset`, que leen `PlayerMovement`, `PlayerJump` y `PlayerLife` |
| R13 | Power ups o sutil modificación de jugabilidad en un caso determinado | Parcial | No hay power up. Lo más cercano es que un enemigo bloqueado por un `Barrel` se frena y dispara (`EnemyFollow.cs:73`), y que la puerta de victoria aparece a los 100 segundos (`BarDoorSpawner.cs:17`). Ninguno cambia la jugabilidad del jugador |
| R14 | El personaje está animado | ✓ | `Assets/Art/Animations/PlayerAnimations/Player.controller` con los parámetros `Speed`, `Grounded`, `Shoot`, `Recharge`, `Death`, `Hurt` y los clips `Idle`, `Run`, `Jump`, `Shoot`, `Recharge`, `Hurt`, `Death` |
| R15 | Escena de menú principal y otra de Gameplay | ✓ | `Assets/Scenes/MainMenu.unity` y `Assets/Scenes/Game.unity`, `ButtonPlay.PlayGame` carga `"Game"` |

## 2. Cumplimiento de Pautas de Cursada

| ID | Pauta | Estado | Evidencia |
|----|-------|--------|-----------|
| P1 | Unity 6000.3.21f1 | ✓ | `ProjectSettings/ProjectVersion.txt` dice `6000.3.21f1` |
| P2 | Repositorio público | ✓ | El repositorio es público |
| P3 | Nombre del repo | ✓ | `TP07_C1_Previtera_CowboyLegend` respeta `TPxx_Cn_Apellido_Titulo` |
| P4 | Código en inglés | ✓ | Clases, métodos, campos y escenas en inglés en los 37 scripts de `Assets/Scripts`. Lo que está en español son strings de UI y logs (`ObjectiveMessage.cs:16`) |
| P5 | Un repo por TP | ✓ | 13 commits, todos del TP07, sin carpetas de otros TPs |

## 3. Estructura de carpetas

| Carpeta esperada | Encontrada | Observación |
|------------------|------------|-------------|
| `Art/Animations/` | ✓ | Separada en `EnemyAnimations/` y `PlayerAnimations/` |
| `Art/Audio/` | ✓ | `Music/`, `SFX/` y `Master.mixer` |
| `Art/Sprites/` | ✓ | |
| `Data/` | ✓ | `PlayerData.asset` |
| `Prefabs/` | ✓ | 11 prefabs |
| `Scenes/` | ✓ | `MainMenu.unity`, `Game.unity` |
| `Scripts/` | ✓ | Organizado por feature (`PlayerScripts/`, `EnemyScripts/`, `UiScripts/`, etc.) en lugar de `Data/`, `Game/`, `Ui/`. Está bien así |

Archivos mal ubicados:

- `Assets/Art/Backgrounds/` (15 imágenes de fondo): son sprites, van en `Assets/Art/Sprites/Backgrounds/`.
- `Assets/Art/Animations/PlayerAnimations/*.png` (`Dead.png`, `Hurt.png`, `Idle.png`, `Jump.png`, `Run.png`, `Shot.png`, `Сharging.png`): son sprite sheets, van en `Assets/Art/Sprites/`. Además `Сharging.png` empieza con una "С" cirílica, no latina.
- `Assets/Scripts/PlayerScripts/PlayerDataSO.cs`: te sugiero `Assets/Scripts/Data/`, aunque como organizaste todo por feature, así también es consistente.

Hay cosas que sobran en el repo: `.plastic/` e `ignore.conf` de Plastic SCM en la raíz, y `Assets/InputSystem_Actions.inputactions` de la plantilla, que no usás (el input es con `Input.GetKey`).

## 4. Qué le falta
- La barra de vida del enemigo con un Canvas en World Space (R7).
- Sonido al agarrar munición y vida (R10).
- Un power up o una modificación de jugabilidad para el jugador (R13).
- Poder disparar hacia la izquierda (`PlayerShoot.cs:50`).
- Bloquear el input de disparo, salto y pausa cuando el juego está pausado o terminado.
- Encapsular los campos `public` de `AudioManager`, `GameManager`, `CameraFollow`, `GroundSpawn` y los menús.
- Que el nombre de la clase coincida con el del archivo en `PauseMenu.cs`, `AmmoPickUp.cs`, `BarrelScripts.cs` y `HealthPickableScript.cs`.

## 5. Hallazgos de código

### Error (6)
- `Assets/Scripts/EnemyScripts/EnemyHealthBar.cs:4` La barra de vida usa `SpriteRenderer` y la escala del `Transform`, no un Canvas en World Space (R7).
- `Assets/Scripts/AmmoScripts/AmmoPickUp.cs:12` Agarrar munición no reproduce sonido, y lo mismo pasa en `HealthPickable` (R10).
- `Assets/Scripts/PickablesScripts/HealthPickableScript.cs:2` La clase `HealthPickable` está en un archivo que se llama distinto. Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
- `Assets/Scripts/BarrelScripts/BarrelScripts.cs:2` La clase `Barrel` está en un archivo que se llama distinto. Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
- `Assets/Scripts/AmmoScripts/AmmoPickUp.cs:2` La clase `AmmoPickup` está en un archivo que se llama distinto (difiere en mayúsculas). Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
- `Assets/Scripts/UiScripts/PauseMenu.cs:2` La clase `Pausemenu` está en un archivo que se llama distinto (difiere en mayúsculas). Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.

### Bug (3)
- `Assets/Scripts/PlayerScripts/PlayerShoot.cs:24` Podés disparar (y saltar, en `PlayerJump.Update`) con `Time.timeScale` en 0 o con el jugador muerto.
- `Assets/Scripts/PlayerScripts/PlayerShoot.cs:50` La bala siempre sale con `Vector2.right`, no se puede disparar a la izquierda.
- `Assets/Scripts/UiScripts/PauseMenu.cs:12` Escape reanuda el juego (`timeScale = 1`) aunque esté abierto el panel de game over o de victoria.

### Warning (21)
- `Assets/Scripts/PlayerScripts/PlayerJump.cs:19` Strings mágicos en los parámetros del Animator.
- `Assets/Scripts/PlayerScripts/PlayerJump.cs:33` `isGrounded` depende del componente `Ground`, así que arriba de un `Barrel` no podés volver a saltar.
- `Assets/Scripts/PlayerScripts/PlayerMovement.cs:34` El sonido de correr arranca en el aire, en pausa y con el jugador muerto.
- `Assets/Scripts/PlayerScripts/PlayerLife.cs:4` `gameManager` es public.
- `Assets/Scripts/GameManagerScripts/GameManager.cs:6` `GameOverPanel` y `deathDelay` son public.
- `Assets/Scripts/GameManagerScripts/GameManager.cs:34` `"Game"` es un string mágico repetido en tres scripts.
- `Assets/Scripts/AudioScripts/AudioManager.cs:6` `Instance` es public con set libre.
- `Assets/Scripts/AudioScripts/AudioManager.cs:10` Mixer, fuentes y clips son public.
- `Assets/Scripts/AudioScripts/AudioManager.cs:33` `FindMatchingGroups(...)[0]` sin validar el resultado.
- `Assets/Scripts/AudioScripts/AudioManager.cs:41` `"MainMenu"` como string mágico.
- `Assets/Scripts/AudioScripts/SettingsAudio.cs:18` El `Debug.Log` en cada cambio de slider llena la consola.
- `Assets/Scripts/EnemyScripts/EnemySpawner.cs:49` `FindObjectsByType` en runtime, repetido dentro de `IsFree`.
- `Assets/Scripts/BarrelScripts/BarrelSpawner.cs:49` El mismo `FindObjectsByType` en runtime.
- `Assets/Scripts/PickablesScripts/HealthPickableSpawner.cs:45` El mismo `FindObjectsByType` en runtime.
- `Assets/Scripts/CameraScripts/CameraFollow.cs:4` `player` es public.
- `Assets/Scripts/GroundScripts/GroundSpawn.cs:4` Campos public.
- `Assets/Scripts/UiScripts/PauseMenu.cs:6` Paneles public y sin camelCase.
- `Assets/Scripts/BarDoorScripts/BarDoor.cs:10` `FindFirstObjectByType` en runtime sin null check.
- `Assets/Scripts/UiScripts/CreditsMenu.cs:4` Campos public.
- `Assets/Scripts/UiScripts/SettingsMenu.cs:4` Campos public.
- `README.md` / itch.io: la página del juego en itch enlaza tu perfil de GitHub y no el repositorio. Enlazá el repo directo.

### Suggestion (8)
- `Assets/Scripts/EnemyScripts/EnemySpawner.cs:78` La lógica de spawn está duplicada en los tres spawners.
- `Assets/Scripts/CameraScripts/CameraFollow.cs:6` `smoothSpeed` sin uso.
- `Assets/Scripts/CameraScripts/CameraFollow.cs:13` Seguimiento de cámara en `LateUpdate`.
- `Assets/Scripts/PickablesScripts/HealthPickableScript.cs:8` Usás `GetComponent` y en los otros pickables `GetComponentInParent`.
- `Assets/Scripts/BulletScripts/EnemyBulletCollision.cs:7` `Debug.Log` marcado como TEMPORAL.
- `Assets/Scripts/UiScripts/ButtonPlay.cs:3` `using UnityEngine.Audio` sin uso.
- `Assets/Scripts/BulletScripts/BulletCollission.cs:2` Error de ortografía en el nombre de la clase.
- `Assets/Scripts/UiScripts/ObjectiveMessage.cs:14` El texto y los 100 segundos están hardcodeados y se pueden desincronizar de `BarDoorSpawner.timeToAppear`.

## 6. Recomendaciones

1. Rehacé la barra de vida del enemigo como un Canvas en World Space hijo de `Enemy.prefab`, con una `Image` en modo Filled (R7).
2. Agregá un clip de pickup en `AudioManager` y llamalo desde `AmmoPickup` y `HealthPickable` (R10).
3. Agregá un power up para el jugador (por ejemplo, disparo más rápido o munición infinita por unos segundos) configurado en un ScriptableObject (R13).
4. Calculá la dirección de la bala en `PlayerShoot.Shoot` según hacia dónde mira el personaje.
5. Cortá el input de `PlayerShoot`, `PlayerJump`, `PlayerMovement` y `Pausemenu` cuando el juego está pausado o terminado.
6. Renombrá clases o archivos para que coincidan (`PauseMenu`, `AmmoPickup`, `Barrel`, `HealthPickable`).
7. Pasá a `[SerializeField] private` los campos public de `AudioManager`, `GameManager`, `CameraFollow`, `GroundSpawn`, `CreditsMenu`, `SettingsMenu` y `Pausemenu`.
8. Reemplazá los `FindObjectsByType` de los spawners por listas registradas y unificá los tres spawners en una clase base.
9. Sacá los `Debug.Log` de `SettingsAudio` y `EnemyBulletCollision`, y mové los sprites a `Art/Sprites/`.
