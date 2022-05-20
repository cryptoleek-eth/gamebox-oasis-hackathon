(this.webpackJsonpweb3gl=this.webpackJsonpweb3gl||[]).push([[35],{1516:function(e,n,r){"use strict";r.r(n),function(e){r.d(n,"default",(function(){return T}));var t=r(2),o=r.n(t),i=r(38),a=r(1),u=r(4),s=r(10),c=r(5),d=r(6),p=r(1517),f=r(856),l=r(710),g=r(605);function E(e,n,r){var t=new g.TransportError(n,r);return t.originalError=e,t}var h=function(e){return e.replace(/\+/g,"-").replace(/\//g,"_").replace(/=+$/,"")};function v(n,r,t,o){var i=function(n,r){for(var t=e.alloc(n.length),o=0;o<n.length;o++)t[o]=n[o]^r[o%r.length];return t}(n,t),a=e.from("0000000000000000000000000000000000000000000000000000000000000000","hex"),u={version:"U2F_V2",keyHandle:h(i.toString("base64")),challenge:h(a.toString("base64")),appId:location.origin};return Object(l.a)("apdu","=> "+n.toString("hex")),Object(p.sign)(u,r/1e3).then((function(n){var r,t=n.signatureData;if("string"===typeof t){var i,a=e.from((r=t).replace(/-/g,"+").replace(/_/g,"/")+"==".substring(0,3*r.length%4),"base64");return i=o?a.slice(5):a,Object(l.a)("apdu","<= "+i.toString("hex")),i}throw n}))}var m=[];var T=function(n){Object(c.a)(t,n);var r=Object(d.a)(t);function t(){var e;return Object(a.a)(this,t),(e=r.call(this)).scrambleKey=void 0,e.unwrap=!0,m.push(Object(s.a)(e)),e}return Object(u.a)(t,[{key:"exchange",value:function(){var e=Object(i.a)(o.a.mark((function e(n){return o.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,e.next=3,v(n,this.exchangeTimeout,this.scrambleKey,this.unwrap);case 3:return e.abrupt("return",e.sent);case 6:if(e.prev=6,e.t0=e.catch(0),!("object"===typeof e.t0.metaData)){e.next=14;break}throw 5===e.t0.metaData.code&&(m.forEach((function(e){return e.emit("disconnect")})),m=[]),E(e.t0,"Failed to sign with Ledger device: U2F "+e.t0.metaData.type,"U2F_"+e.t0.metaData.code);case 14:throw e.t0;case 15:case"end":return e.stop()}}),e,this,[[0,6]])})));return function(n){return e.apply(this,arguments)}}()},{key:"setScrambleKey",value:function(n){this.scrambleKey=e.from(n,"ascii")}},{key:"setUnwrap",value:function(e){this.unwrap=e}},{key:"close",value:function(){return Promise.resolve()}}],[{key:"open",value:function(){var e=Object(i.a)(o.a.mark((function e(n){var r=arguments;return o.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return r.length>1&&void 0!==r[1]?r[1]:5e3,e.abrupt("return",new t);case 2:case"end":return e.stop()}}),e)})));return function(n){return e.apply(this,arguments)}}()}]),t}(f.a);T.isSupported=p.isSupported,T.list=function(){return Object(p.isSupported)().then((function(e){return e?[null]:[]}))},T.listen=function(e){var n=!1;return Object(p.isSupported)().then((function(r){n||(r?(e.next({type:"add",descriptor:null}),e.complete()):e.error(new g.TransportError("U2F browser support is needed for Ledger. Please use Chrome, Opera or Firefox with a U2F extension. Also make sure you're on an HTTPS connection","U2FNotSupported")))})),{unsubscribe:function(){n=!0}}}}.call(this,r(8).Buffer)},1517:function(e,n,r){"use strict";e.exports=r(1518)},1518:function(e,n,r){"use strict";(function(n){e.exports=c;var t=r(1519),o="undefined"!==typeof navigator&&!!navigator.userAgent,i=o&&navigator.userAgent.match(/Safari\//)&&!navigator.userAgent.match(/Chrome\//),a=o&&navigator.userAgent.match(/Edge\/1[2345]/),u=null;function s(e){return u||(u=new e((function(e,n){function r(){e({u2f:null,native:!0})}return o?i?r():("undefined"!==typeof window.u2f&&"function"===typeof window.u2f.sign&&e({u2f:window.u2f,native:!0}),a||"http:"===location.protocol||"undefined"===typeof MessageChannel?r():void t.isSupported((function(n){n?e({u2f:t,native:!1}):r()}))):r()}))),u}function c(e){return{isSupported:f.bind(e),ensureSupport:g.bind(e),register:E.bind(e),sign:h.bind(e),ErrorCodes:c.ErrorCodes,ErrorNames:c.ErrorNames}}function d(e,n){var r=null!=n?n.errorCode:1,t=c.ErrorNames[""+r],o=new Error(e);return o.metaData={type:t,code:r},o}function p(e,n){var r={};return r.promise=new e((function(e,t){r.resolve=e,r.reject=t,n.then(e,t)})),r.promise.cancel=function(n,t){s(e).then((function(e){t&&!e.native&&e.u2f.disconnect(),r.reject(d(n,{errorCode:-1}))}))},r}function f(){return s(this).then((function(e){return!!e.u2f}))}function l(e){if(!e.u2f){if("http:"===location.protocol)throw new Error("U2F isn't supported over http, only https");throw new Error("U2F not supported")}}function g(){return s(this).then(l)}function E(e,n,r){var t=this;return Array.isArray(e)||(e=[e]),"number"===typeof n&&"undefined"===typeof r&&(r=n,n=null),n||(n=[]),p(t,s(t).then((function(o){l(o);var i=o.native,a=o.u2f;return new t((function(t,o){if(i){var u=e[0].appId;a.register(u,e,n,(function(e){e.errorCode?o(d("Registration failed",e)):(delete e.errorCode,t(e))}),r)}else a.register(e,n,(function(e,n){e?o(e):n.errorCode?o(d("Registration failed",n)):t(n)}),r)}))}))).promise}function h(e,n){var r=this;return Array.isArray(e)||(e=[e]),p(r,s(r).then((function(t){l(t);var o=t.native,i=t.u2f;return new r((function(r,t){if(o){var a=e[0].appId,u=e[0].challenge;i.sign(a,u,e,(function(e){e.errorCode?t(d("Sign failed",e)):(delete e.errorCode,r(e))}),n)}else i.sign(e,(function(e,n){e?t(e):n.errorCode?t(d("Sign failed",n)):r(n)}),n)}))}))).promise}function v(e){c[e]=function(){if(!n.Promise)throw new Error("The platform doesn't natively support promises");var r=[].slice.call(arguments);return c(n.Promise)[e].apply(null,r)}}c.ErrorCodes={CANCELLED:-1,OK:0,OTHER_ERROR:1,BAD_REQUEST:2,CONFIGURATION_UNSUPPORTED:3,DEVICE_INELIGIBLE:4,TIMEOUT:5},c.ErrorNames={"-1":"CANCELLED",0:"OK",1:"OTHER_ERROR",2:"BAD_REQUEST",3:"CONFIGURATION_UNSUPPORTED",4:"DEVICE_INELIGIBLE",5:"TIMEOUT"},v("isSupported"),v("ensureSupport"),v("register"),v("sign")}).call(this,r(19))},1519:function(e,n,r){"use strict";var t=t||{};e.exports=t,t.EXTENSION_ID="kmendfapggjehodndflmmgagdbamhnfd",t.MessageTypes={U2F_REGISTER_REQUEST:"u2f_register_request",U2F_SIGN_REQUEST:"u2f_sign_request",U2F_REGISTER_RESPONSE:"u2f_register_response",U2F_SIGN_RESPONSE:"u2f_sign_response"},t.ErrorCodes={OK:0,OTHER_ERROR:1,BAD_REQUEST:2,CONFIGURATION_UNSUPPORTED:3,DEVICE_INELIGIBLE:4,TIMEOUT:5},t.Request,t.Response,t.Error,t.SignRequest,t.SignResponse,t.RegisterRequest,t.RegisterResponse,t.disconnect=function(){t.port_&&t.port_.port_&&(t.port_.port_.disconnect(),t.port_=null)},t.getMessagePort=function(e){if("undefined"!=typeof chrome&&chrome.runtime){var n={type:t.MessageTypes.U2F_SIGN_REQUEST,signRequests:[]};chrome.runtime.sendMessage(t.EXTENSION_ID,n,(function(){chrome.runtime.lastError?t.getIframePort_(e):t.getChromeRuntimePort_(e)}))}else t.getIframePort_(e)},t.getChromeRuntimePort_=function(e){var n=chrome.runtime.connect(t.EXTENSION_ID,{includeTlsChannelId:!0});setTimeout((function(){e(null,new t.WrappedChromeRuntimePort_(n))}),0)},t.WrappedChromeRuntimePort_=function(e){this.port_=e},t.WrappedChromeRuntimePort_.prototype.postMessage=function(e){this.port_.postMessage(e)},t.WrappedChromeRuntimePort_.prototype.addEventListener=function(e,n){var r=e.toLowerCase();"message"==r||"onmessage"==r?this.port_.onMessage.addListener((function(e){n({data:e})})):console.error("WrappedChromeRuntimePort only supports onMessage")},t.getIframePort_=function(e){var n="chrome-extension://"+t.EXTENSION_ID,r=document.createElement("iframe");r.src=n+"/u2f-comms.html",r.setAttribute("style","display:none"),document.body.appendChild(r);var o=!1,i=new MessageChannel;i.port1.addEventListener("message",(function n(r){"ready"==r.data?(i.port1.removeEventListener("message",n),o||(o=!0,e(null,i.port1))):console.error('First event on iframe port was not "ready"')})),i.port1.start(),r.addEventListener("load",(function(){r.contentWindow.postMessage("init",n,[i.port2])})),setTimeout((function(){o||(o=!0,e(new Error("IFrame extension not supported")))}),200)},t.EXTENSION_TIMEOUT_SEC=30,t.port_=null,t.waitingForPort_=[],t.reqCounter_=0,t.callbackMap_={},t.getPortSingleton_=function(e){t.port_?e(null,t.port_):(0==t.waitingForPort_.length&&t.getMessagePort((function(e,n){for(e||(t.port_=n,t.port_.addEventListener("message",t.responseHandler_));t.waitingForPort_.length;)t.waitingForPort_.shift()(e,n)})),t.waitingForPort_.push(e))},t.responseHandler_=function(e){var n=e.data,r=n.requestId;if(r&&t.callbackMap_[r]){var o=t.callbackMap_[r];delete t.callbackMap_[r],o(null,n.responseData)}else console.error("Unknown or missing requestId in response.")},t.isSupported=function(e){t.getPortSingleton_((function(n,r){e(!n)}))},t.sign=function(e,n,r){t.getPortSingleton_((function(o,i){if(o)return n(o);var a=++t.reqCounter_;t.callbackMap_[a]=n;var u={type:t.MessageTypes.U2F_SIGN_REQUEST,signRequests:e,timeoutSeconds:"undefined"!==typeof r?r:t.EXTENSION_TIMEOUT_SEC,requestId:a};i.postMessage(u)}))},t.register=function(e,n,r,o){t.getPortSingleton_((function(i,a){if(i)return r(i);var u=++t.reqCounter_;t.callbackMap_[u]=r;var s={type:t.MessageTypes.U2F_REGISTER_REQUEST,signRequests:n,registerRequests:e,timeoutSeconds:"undefined"!==typeof o?o:t.EXTENSION_TIMEOUT_SEC,requestId:u};a.postMessage(s)}))}},605:function(e,n,r){"use strict";r.r(n),r.d(n,"AccountNameRequiredError",(function(){return d})),r.d(n,"AccountNotSupported",(function(){return p})),r.d(n,"AmountRequired",(function(){return f})),r.d(n,"BluetoothRequired",(function(){return l})),r.d(n,"BtcUnmatchedApp",(function(){return g})),r.d(n,"CantOpenDevice",(function(){return E})),r.d(n,"CantScanQRCode",(function(){return Le})),r.d(n,"CashAddrNotSupported",(function(){return h})),r.d(n,"CurrencyNotSupported",(function(){return v})),r.d(n,"DBNotReset",(function(){return Qe})),r.d(n,"DBWrongPassword",(function(){return ze})),r.d(n,"DeviceAppVerifyNotSupported",(function(){return m})),r.d(n,"DeviceGenuineSocketEarlyClose",(function(){return T})),r.d(n,"DeviceHalted",(function(){return A})),r.d(n,"DeviceInOSUExpected",(function(){return S})),r.d(n,"DeviceNameInvalid",(function(){return R})),r.d(n,"DeviceNotGenuineError",(function(){return _})),r.d(n,"DeviceOnDashboardExpected",(function(){return I})),r.d(n,"DeviceOnDashboardUnexpected",(function(){return N})),r.d(n,"DeviceShouldStayInApp",(function(){return Ue})),r.d(n,"DeviceSocketFail",(function(){return D})),r.d(n,"DeviceSocketNoBulkStatus",(function(){return C})),r.d(n,"DisconnectedDevice",(function(){return O})),r.d(n,"DisconnectedDeviceDuringOperation",(function(){return y})),r.d(n,"ETHAddressNonEIP",(function(){return ke})),r.d(n,"EnpointConfigError",(function(){return w})),r.d(n,"EthAppPleaseEnableContractData",(function(){return U})),r.d(n,"FeeEstimationFailed",(function(){return b})),r.d(n,"FeeNotLoaded",(function(){return xe})),r.d(n,"FeeRequired",(function(){return Be})),r.d(n,"FeeTooHigh",(function(){return Ge})),r.d(n,"FirmwareNotRecognized",(function(){return P})),r.d(n,"FirmwareOrAppUpdateRequired",(function(){return Ve})),r.d(n,"GasLessThanEstimate",(function(){return ue})),r.d(n,"GenuineCheckFailed",(function(){return He})),r.d(n,"HardResetFail",(function(){return F})),r.d(n,"InvalidAddress",(function(){return k})),r.d(n,"InvalidAddressBecauseDestinationIsAlsoSource",(function(){return L})),r.d(n,"InvalidXRPTag",(function(){return M})),r.d(n,"LatestMCUInstalledError",(function(){return x})),r.d(n,"LedgerAPI4xx",(function(){return We})),r.d(n,"LedgerAPI5xx",(function(){return Ke})),r.d(n,"LedgerAPIError",(function(){return G})),r.d(n,"LedgerAPIErrorWithMessage",(function(){return q})),r.d(n,"LedgerAPINotAvailable",(function(){return j})),r.d(n,"MCUNotGenuineToDashboard",(function(){return ge})),r.d(n,"ManagerAppAlreadyInstalledError",(function(){return H})),r.d(n,"ManagerAppDepInstallRequired",(function(){return K})),r.d(n,"ManagerAppDepUninstallRequired",(function(){return V})),r.d(n,"ManagerAppRelyOnBTCError",(function(){return W})),r.d(n,"ManagerDeviceLockedError",(function(){return X})),r.d(n,"ManagerFirmwareNotEnoughSpaceError",(function(){return z})),r.d(n,"ManagerNotEnoughSpaceError",(function(){return Q})),r.d(n,"ManagerUninstallBTCDep",(function(){return Y})),r.d(n,"NetworkDown",(function(){return J})),r.d(n,"NoAccessToCamera",(function(){return oe})),r.d(n,"NoAddressesFound",(function(){return Z})),r.d(n,"NoDBPathGiven",(function(){return Xe})),r.d(n,"NotEnoughBalance",(function(){return $})),r.d(n,"NotEnoughBalanceBecauseDestinationNotCreated",(function(){return te})),r.d(n,"NotEnoughBalanceInParentAccount",(function(){return ne})),r.d(n,"NotEnoughBalanceToDelegate",(function(){return ee})),r.d(n,"NotEnoughGas",(function(){return ie})),r.d(n,"NotEnoughSpendableBalance",(function(){return re})),r.d(n,"NotSupportedLegacyAddress",(function(){return ae})),r.d(n,"PairingFailed",(function(){return je})),r.d(n,"PasswordIncorrectError",(function(){return ce})),r.d(n,"PasswordsDontMatchError",(function(){return se})),r.d(n,"RecipientRequired",(function(){return Ee})),r.d(n,"RecommendSubAccountsToEmpty",(function(){return de})),r.d(n,"RecommendUndelegation",(function(){return pe})),r.d(n,"StatusCodes",(function(){return Je})),r.d(n,"SyncError",(function(){return qe})),r.d(n,"TimeoutTagged",(function(){return fe})),r.d(n,"TransportError",(function(){return Ye})),r.d(n,"TransportInterfaceNotAvailable",(function(){return Oe})),r.d(n,"TransportOpenUserCancelled",(function(){return Ce})),r.d(n,"TransportRaceCondition",(function(){return ye})),r.d(n,"TransportStatusError",(function(){return $e})),r.d(n,"TransportWebUSBGestureRequired",(function(){return we})),r.d(n,"UnavailableTezosOriginatedAccountReceive",(function(){return he})),r.d(n,"UnavailableTezosOriginatedAccountSend",(function(){return ve})),r.d(n,"UnexpectedBootloader",(function(){return le})),r.d(n,"UnknownMCU",(function(){return B})),r.d(n,"UpdateFetchFileFail",(function(){return me})),r.d(n,"UpdateIncorrectHash",(function(){return Te})),r.d(n,"UpdateIncorrectSig",(function(){return _e})),r.d(n,"UpdateYourApp",(function(){return Ie})),r.d(n,"UserRefusedAddress",(function(){return Se})),r.d(n,"UserRefusedAllowManager",(function(){return Re})),r.d(n,"UserRefusedDeviceNameChange",(function(){return Ne})),r.d(n,"UserRefusedFirmwareUpdate",(function(){return Ae})),r.d(n,"UserRefusedOnDevice",(function(){return De})),r.d(n,"WebsocketConnectionError",(function(){return be})),r.d(n,"WebsocketConnectionFailed",(function(){return Pe})),r.d(n,"WrongAppForCurrency",(function(){return Me})),r.d(n,"WrongDeviceForAccount",(function(){return Fe})),r.d(n,"addCustomErrorDeserializer",(function(){return i})),r.d(n,"createCustomErrorClass",(function(){return a})),r.d(n,"deserializeError",(function(){return u})),r.d(n,"getAltStatusMessage",(function(){return Ze})),r.d(n,"serializeError",(function(){return s}));var t={},o={},i=function(e,n){o[e]=n},a=function(e){var n=function(n,r){Object.assign(this,r),this.name=e,this.message=n||e,this.stack=(new Error).stack};return n.prototype=new Error,t[e]=n,n},u=function e(n){if("object"===typeof n&&n){try{var r=JSON.parse(n.message);r.message&&r.name&&(n=r)}catch(p){}var i=void 0;if("string"===typeof n.name){var u=n.name,s=o[u];if(s)i=s(n);else{var c="Error"===u?Error:t[u];c||(console.warn("deserializing an unknown class '"+u+"'"),c=a(u)),i=Object.create(c.prototype);try{for(var d in n)n.hasOwnProperty(d)&&(i[d]=n[d])}catch(p){}}}else i=new Error(n.message);return!i.stack&&Error.captureStackTrace&&Error.captureStackTrace(i,e),i}return new Error(String(n))},s=function(e){return e?"object"===typeof e?c(e,[]):"function"===typeof e?"[Function: "+(e.name||"anonymous")+"]":e:e};function c(e,n){var r={};n.push(e);for(var t=0,o=Object.keys(e);t<o.length;t++){var i=o[t],a=e[i];"function"!==typeof a&&(a&&"object"===typeof a?-1!==n.indexOf(e[i])?r[i]="[Circular]":r[i]=c(e[i],n.slice(0)):r[i]=a)}return"string"===typeof e.name&&(r.name=e.name),"string"===typeof e.message&&(r.message=e.message),"string"===typeof e.stack&&(r.stack=e.stack),r}var d=a("AccountNameRequired"),p=a("AccountNotSupported"),f=a("AmountRequired"),l=a("BluetoothRequired"),g=a("BtcUnmatchedApp"),E=a("CantOpenDevice"),h=a("CashAddrNotSupported"),v=a("CurrencyNotSupported"),m=a("DeviceAppVerifyNotSupported"),T=a("DeviceGenuineSocketEarlyClose"),_=a("DeviceNotGenuine"),I=a("DeviceOnDashboardExpected"),N=a("DeviceOnDashboardUnexpected"),S=a("DeviceInOSUExpected"),A=a("DeviceHalted"),R=a("DeviceNameInvalid"),D=a("DeviceSocketFail"),C=a("DeviceSocketNoBulkStatus"),O=a("DisconnectedDevice"),y=a("DisconnectedDeviceDuringOperation"),w=a("EnpointConfig"),U=a("EthAppPleaseEnableContractData"),b=a("FeeEstimationFailed"),P=a("FirmwareNotRecognized"),F=a("HardResetFail"),M=a("InvalidXRPTag"),k=a("InvalidAddress"),L=a("InvalidAddressBecauseDestinationIsAlsoSource"),x=a("LatestMCUInstalledError"),B=a("UnknownMCU"),G=a("LedgerAPIError"),q=a("LedgerAPIErrorWithMessage"),j=a("LedgerAPINotAvailable"),H=a("ManagerAppAlreadyInstalled"),W=a("ManagerAppRelyOnBTC"),K=a("ManagerAppDepInstallRequired"),V=a("ManagerAppDepUninstallRequired"),X=a("ManagerDeviceLocked"),z=a("ManagerFirmwareNotEnoughSpace"),Q=a("ManagerNotEnoughSpace"),Y=a("ManagerUninstallBTCDep"),J=a("NetworkDown"),Z=a("NoAddressesFound"),$=a("NotEnoughBalance"),ee=a("NotEnoughBalanceToDelegate"),ne=a("NotEnoughBalanceInParentAccount"),re=a("NotEnoughSpendableBalance"),te=a("NotEnoughBalanceBecauseDestinationNotCreated"),oe=a("NoAccessToCamera"),ie=a("NotEnoughGas"),ae=a("NotSupportedLegacyAddress"),ue=a("GasLessThanEstimate"),se=a("PasswordsDontMatch"),ce=a("PasswordIncorrect"),de=a("RecommendSubAccountsToEmpty"),pe=a("RecommendUndelegation"),fe=a("TimeoutTagged"),le=a("UnexpectedBootloader"),ge=a("MCUNotGenuineToDashboard"),Ee=a("RecipientRequired"),he=a("UnavailableTezosOriginatedAccountReceive"),ve=a("UnavailableTezosOriginatedAccountSend"),me=a("UpdateFetchFileFail"),Te=a("UpdateIncorrectHash"),_e=a("UpdateIncorrectSig"),Ie=a("UpdateYourApp"),Ne=a("UserRefusedDeviceNameChange"),Se=a("UserRefusedAddress"),Ae=a("UserRefusedFirmwareUpdate"),Re=a("UserRefusedAllowManager"),De=a("UserRefusedOnDevice"),Ce=a("TransportOpenUserCancelled"),Oe=a("TransportInterfaceNotAvailable"),ye=a("TransportRaceCondition"),we=a("TransportWebUSBGestureRequired"),Ue=a("DeviceShouldStayInApp"),be=a("WebsocketConnectionError"),Pe=a("WebsocketConnectionFailed"),Fe=a("WrongDeviceForAccount"),Me=a("WrongAppForCurrency"),ke=a("ETHAddressNonEIP"),Le=a("CantScanQRCode"),xe=a("FeeNotLoaded"),Be=a("FeeRequired"),Ge=a("FeeTooHigh"),qe=a("SyncError"),je=a("PairingFailed"),He=a("GenuineCheckFailed"),We=a("LedgerAPI4xx"),Ke=a("LedgerAPI5xx"),Ve=a("FirmwareOrAppUpdateRequired"),Xe=a("NoDBPathGiven"),ze=a("DBWrongPassword"),Qe=a("DBNotReset");function Ye(e,n){this.name="TransportError",this.message=e,this.stack=(new Error).stack,this.id=n}Ye.prototype=new Error,i("TransportError",(function(e){return new Ye(e.message,e.id)}));var Je={PIN_REMAINING_ATTEMPTS:25536,INCORRECT_LENGTH:26368,MISSING_CRITICAL_PARAMETER:26624,COMMAND_INCOMPATIBLE_FILE_STRUCTURE:27009,SECURITY_STATUS_NOT_SATISFIED:27010,CONDITIONS_OF_USE_NOT_SATISFIED:27013,INCORRECT_DATA:27264,NOT_ENOUGH_MEMORY_SPACE:27268,REFERENCED_DATA_NOT_FOUND:27272,FILE_ALREADY_EXISTS:27273,INCORRECT_P1_P2:27392,INS_NOT_SUPPORTED:27904,CLA_NOT_SUPPORTED:28160,TECHNICAL_PROBLEM:28416,OK:36864,MEMORY_PROBLEM:37440,NO_EF_SELECTED:37888,INVALID_OFFSET:37890,FILE_NOT_FOUND:37892,INCONSISTENT_FILE:37896,ALGORITHM_NOT_SUPPORTED:38020,INVALID_KCV:38021,CODE_NOT_INITIALIZED:38914,ACCESS_CONDITION_NOT_FULFILLED:38916,CONTRADICTION_SECRET_CODE_STATUS:38920,CONTRADICTION_INVALIDATION:38928,CODE_BLOCKED:38976,MAX_VALUE_REACHED:38992,GP_AUTH_FAILED:25344,LICENSING:28482,HALTED:28586};function Ze(e){switch(e){case 26368:return"Incorrect length";case 26624:return"Missing critical parameter";case 27010:return"Security not satisfied (dongle locked or have invalid access rights)";case 27013:return"Condition of use not satisfied (denied by the user?)";case 27264:return"Invalid data received";case 27392:return"Invalid parameter received"}if(28416<=e&&e<=28671)return"Internal error, please report"}function $e(e){this.name="TransportStatusError";var n=Object.keys(Je).find((function(n){return Je[n]===e}))||"UNKNOWN_ERROR",r=Ze(e)||n,t=e.toString(16);this.message="Ledger device: "+r+" (0x"+t+")",this.stack=(new Error).stack,this.statusCode=e,this.statusText=n}$e.prototype=new Error,i("TransportStatusError",(function(e){return new $e(e.statusCode)}))},710:function(e,n,r){"use strict";r.d(n,"a",(function(){return i}));var t=0,o=[],i=function(e,n,r){var i={type:e,id:String(++t),date:new Date};n&&(i.message=n),r&&(i.data=r),function(e){for(var n=0;n<o.length;n++)try{o[n](e)}catch(r){console.error(r)}}(i)};"undefined"!==typeof window&&(window.__ledgerLogsListen=function(e){return o.push(e),function(){var n=o.indexOf(e);-1!==n&&(o[n]=o[o.length-1],o.pop())}})},856:function(e,n,r){"use strict";(function(e){r.d(n,"a",(function(){return f}));var t=r(146),o=r(2),i=r.n(o),a=r(38),u=r(1),s=r(4),c=r(43),d=r.n(c),p=r(605),f=function(){function n(){var r=this;Object(u.a)(this,n),this.exchangeTimeout=3e4,this.unresponsiveTimeout=15e3,this.deviceModel=null,this._events=new d.a,this.send=function(){var n=Object(a.a)(i.a.mark((function n(t,o,a,u){var s,c,d,f,l=arguments;return i.a.wrap((function(n){for(;;)switch(n.prev=n.next){case 0:if(s=l.length>4&&void 0!==l[4]?l[4]:e.alloc(0),c=l.length>5&&void 0!==l[5]?l[5]:[p.StatusCodes.OK],!(s.length>=256)){n.next=4;break}throw new p.TransportError("data.length exceed 256 bytes limit. Got: "+s.length,"DataLengthTooBig");case 4:return n.next=6,r.exchange(e.concat([e.from([t,o,a,u]),e.from([s.length]),s]));case 6:if(d=n.sent,f=d.readUInt16BE(d.length-2),c.some((function(e){return e===f}))){n.next=10;break}throw new p.TransportStatusError(f);case 10:return n.abrupt("return",d);case 11:case"end":return n.stop()}}),n)})));return function(e,r,t,o){return n.apply(this,arguments)}}(),this.exchangeBusyPromise=void 0,this.exchangeAtomicImpl=function(){var e=Object(a.a)(i.a.mark((function e(n){var t,o,a,u,s;return i.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:if(!r.exchangeBusyPromise){e.next=2;break}throw new p.TransportRaceCondition("An action was already pending on the Ledger device. Please deny or reconnect.");case 2:return o=new Promise((function(e){t=e})),r.exchangeBusyPromise=o,a=!1,u=setTimeout((function(){a=!0,r.emit("unresponsive")}),r.unresponsiveTimeout),e.prev=6,e.next=9,n();case 9:return s=e.sent,a&&r.emit("responsive"),e.abrupt("return",s);case 12:return e.prev=12,clearTimeout(u),t&&t(),r.exchangeBusyPromise=null,e.finish(12);case 17:case"end":return e.stop()}}),e,null,[[6,,12,17]])})));return function(n){return e.apply(this,arguments)}}(),this._appAPIlock=null}return Object(s.a)(n,[{key:"exchange",value:function(e){throw new Error("exchange not implemented")}},{key:"setScrambleKey",value:function(e){}},{key:"close",value:function(){return Promise.resolve()}},{key:"on",value:function(e,n){this._events.on(e,n)}},{key:"off",value:function(e,n){this._events.removeListener(e,n)}},{key:"emit",value:function(e){for(var n,r=arguments.length,t=new Array(r>1?r-1:0),o=1;o<r;o++)t[o-1]=arguments[o];(n=this._events).emit.apply(n,[e].concat(t))}},{key:"setDebugMode",value:function(){console.warn("setDebugMode is deprecated. use @ledgerhq/logs instead. No logs are emitted in this anymore.")}},{key:"setExchangeTimeout",value:function(e){this.exchangeTimeout=e}},{key:"setExchangeUnresponsiveTimeout",value:function(e){this.unresponsiveTimeout=e}},{key:"decorateAppAPIMethods",value:function(e,n,r){var o,i=Object(t.a)(n);try{for(i.s();!(o=i.n()).done;){var a=o.value;e[a]=this.decorateAppAPIMethod(a,e[a],e,r)}}catch(u){i.e(u)}finally{i.f()}}},{key:"decorateAppAPIMethod",value:function(e,n,r,t){var o=this;return Object(a.a)(i.a.mark((function a(){var u,s,c,d,f=arguments;return i.a.wrap((function(i){for(;;)switch(i.prev=i.next){case 0:if(!(u=o._appAPIlock)){i.next=3;break}return i.abrupt("return",Promise.reject(new p.TransportError("Ledger Device is busy (lock "+u+")","TransportLocked")));case 3:for(i.prev=3,o._appAPIlock=e,o.setScrambleKey(t),s=f.length,c=new Array(s),d=0;d<s;d++)c[d]=f[d];return i.next=9,n.apply(r,c);case 9:return i.abrupt("return",i.sent);case 10:return i.prev=10,o._appAPIlock=null,i.finish(10);case 13:case"end":return i.stop()}}),a,null,[[3,,10,13]])})))}}],[{key:"create",value:function(){var e=this,n=arguments.length>0&&void 0!==arguments[0]?arguments[0]:3e3,r=arguments.length>1?arguments[1]:void 0;return new Promise((function(t,o){var i=!1,a=e.listen({next:function(r){i=!0,a&&a.unsubscribe(),u&&clearTimeout(u),e.open(r.descriptor,n).then(t,o)},error:function(e){u&&clearTimeout(u),o(e)},complete:function(){u&&clearTimeout(u),i||o(new p.TransportError(e.ErrorMessage_NoDeviceFound,"NoDeviceFound"))}}),u=r?setTimeout((function(){a.unsubscribe(),o(new p.TransportError(e.ErrorMessage_ListenTimeout,"ListenTimeout"))}),r):null}))}}]),n}();f.isSupported=void 0,f.list=void 0,f.listen=void 0,f.open=void 0,f.ErrorMessage_ListenTimeout="No Ledger device found (timeout)",f.ErrorMessage_NoDeviceFound="No Ledger device found"}).call(this,r(8).Buffer)}}]);
