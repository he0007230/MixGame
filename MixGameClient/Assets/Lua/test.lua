require 'FairyGUI'

function OnStartBtnClick()
    print('StartBtn Click!')
    print(loadMsgText.text)
end
function initLoadUI()
    GRoot.inst:SetContentScaleFactor(640,360)
    UIPackage.AddPackage('FairyGUI/LoadUI/_load')
    mainView = UIPackage.CreateObject('_load','main')
    mainView.fairyBatching = true
    mainView:SetSize(GRoot.inst.width,GRoot.inst.height)
    GRoot.inst:AddChild(mainView)
    loadMsgText = mainView:GetChild("loadMsgText")
    loadMsgText.text = 'this is loadMsgText'
    progressBar = mainView:GetChild("progressBar")
    progressBar.value = 0
    startBtn = mainView:GetChild("startBtn")
    startBtn.onClick:Add(OnStartBtnClick)
end