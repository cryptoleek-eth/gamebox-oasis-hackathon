(this.webpackJsonpweb3gl=this.webpackJsonpweb3gl||[]).push([[74],{551:function(e,n,t){"use strict";t.r(n);var r=t(2),o=t.n(r),i=(t(81),t(139));t(51),t(100),t(99),t(83);function c(e,n){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);n&&(r=r.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),t.push.apply(t,r)}return t}function a(e){for(var n=1;n<arguments.length;n++){var t=null!=arguments[n]?arguments[n]:{};n%2?c(Object(t),!0).forEach((function(n){u(e,n,t[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):c(Object(t)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(t,n))}))}return e}function u(e,n,t){return n in e?Object.defineProperty(e,n,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[n]=t,e}function s(e,n,t,r,o,i,c){try{var a=e[i](c),u=a.value}catch(s){return void t(s)}a.done?n(u):Promise.resolve(u).then(r,o)}function l(e){return function(){var n=this,t=arguments;return new Promise((function(r,o){var i=e.apply(n,t);function c(e){s(i,r,o,c,a,"next",e)}function a(e){s(i,r,o,c,a,"throw",e)}c(void 0)}))}}n.default=function(e){var n=e.networkId,r=e.preferred,c=e.label,u=e.iconSrc,s=e.svg,f=e.buttonPosition,p=e.modalZIndex,b=e.apiKey,d=e.buildEnv,h=e.enableLogging,w=e.enabledVerifiers,g=e.loginConfig,v=e.showTorusButton,y=e.integrity,O=e.whiteLabel,m=e.loginMethod,j=e.rpcUrl;return{name:c||"Torus",svg:s||'<svg width="257" height="277" viewBox="0 0 257 277" fill="none" xmlns="http://www.w3.org/2000/svg">\n<rect width="153.889" height="82.0741" fill="#0364FF" />\n<rect x="71.8135" width="82.0741" height="277" fill="#0364FF" />\n<path d="M215.443 82.0741C238.107 82.0741 256.48 63.7012 256.48 41.037C256.48 18.3729 238.107 0 215.443 \n0C192.779 0 174.406 18.3729 174.406 41.037C174.406 63.7012 192.779 82.0741 215.443 82.0741Z" fill="#0364FF" />\n</svg>',iconSrc:u,wallet:function(){var e=l(o.a.mark((function e(r){var c,u,s,P,k;return o.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return c=r.createModernProviderInterface,e.next=3,t.e(30).then(t.t.bind(null,1341,7));case 3:return u=e.sent,s=u.default,P=new s({buttonPosition:f,modalZIndex:p,apiKey:b}),e.next=8,P.init({buildEnv:d,enableLogging:h,network:{host:j||Object(i.l)(n),chainId:n,networkName:"".concat(Object(i.l)(n)," Network")},showTorusButton:v,enabledVerifiers:w,loginConfig:g,integrity:y,whiteLabel:O});case 8:return k=P.provider,e.abrupt("return",{provider:k,interface:a(a({},c(k)),{},{name:"Torus",dashboard:function(){return P.showWallet("home")},connect:function(){var e=l(o.a.mark((function e(){var n;return o.a.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,P.login({verifier:m});case 2:return n=e.sent,e.abrupt("return",{message:n[0]});case 4:case"end":return e.stop()}}),e)})));return function(){return e.apply(this,arguments)}}(),disconnect:function(){return P.cleanUp()}}),instance:P});case 10:case"end":return e.stop()}}),e)})));return function(n){return e.apply(this,arguments)}}(),type:"sdk",desktop:!0,mobile:!0,preferred:r}}}}]);