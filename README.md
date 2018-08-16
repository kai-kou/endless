# Endless 2D Shooting

迫りくる隕石をひたすら破壊して(多分後ろにある)星を守ろう！


## Description

このゲームはUnity ML-Agentsで強化(PPO)学習を行わせることができるか検証するために作成したUnityの2Dゲームです。  
  
ゲーム作成・Unity利用未経験だったので、下記を参考にゲームのベースを作成しました。感謝！  

【Unity入門】60分で作るシューティングゲーム　第１回  
http://nn-hokuson.hatenablog.com/entry/2016/07/04/213231  
  
ベースを作成後、Unity ML-Agentsで強化学習ができるように実装を追加しました。以下を参考にさせてもらいました。感謝！  
  
  
【Unity ML-Agents】強化学習で物体を避ける  
https://qiita.com/God_KonaBanana/items/e56fcee3ae544be7dfca  
  
【Unity強化学習】自作ゲームで強化学習  
https://qiita.com/God_KonaBanana/items/7aebdb411c99b059cc6f  
  

## Demo

Unity ML-Agentsで強化学習させている様子です。  


## Requirement

UnityとUnity ML-Agentsが必須です。導入方法は以下を参考ください。  
  
  
Macでhomebrewを使ってUnityをインストールする(Unity Hub、日本語化対応)  
https://qiita.com/kai_kou/items/445e614fb71f2204e033  
  
MacでUnity ML-Agentsの環境を構築する  
https://qiita.com/kai_kou/items/6478fa686ce1af5939d8  


## Usage

### Unity上で機械学習させる方法

Unityアプリを起動して、[open]から```git Clone``` したフォルダを開きます。  
  
ターミナルから強化学習開始できるようにコマンドを実行します。  
  
```sh
> cd cloneしたディレクトリ/ml-agents/python
> python learn.py --train
```

Unityアプリで[ゲーム開始(三角)]ボタンをクリックします。  


## Install

```sh
> cd 任意のディレクトリ
> git clone  --recursive https://github.com/kai-kou/endress.git
> cd endress
> python -m venv venv
> cd ml-agents/python
> pip install -r requirements.txt
```
