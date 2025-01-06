var FI;
if (!FI) {
    FI = {};
}

!(function (fi) {
    'use strict';
    fi.utils = {};
    fi.utils.generate_random_char = function () {
        var chars, newchar, rand;
        chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        rand = Math.floor(Math.random() * chars.length);
        return newchar = chars.substring(rand, rand + 1);
    };
    fi.utils.newid = function () {
        var result = '', cnt = 15;
        while (cnt > 0) {
            result += fi.utils.generate_random_char();
            cnt--;
        }
        return result;
    };

    fi.utils.disableEnterKey = function ($el) {
        $el.on('keypress', function (evt) {
            if (evt.keyCode === 13) {
                $(this).change();
                return false;
            }
        });
    };

    fi.utils.initMobile = function () {
        if (fi.isResponsive) {
            /mobile/i.test(navigator.userAgent) && setTimeout(function () { window.scrollTo(0, 1); }, 1000);
            (function () {
                var ua = navigator.userAgent, npF = ' no-mobile-positionfixed';
                if (/(iPhone|iPod|iPad)/i.test(ua)) {
                    fi.isIDevice = true;
                    if (/OS [2-4]_\d(_\d)? like Mac OS X/i.test(navigator.userAgent)) {
                        document.documentElement.className += npF;
                    } else if (/CPU like Mac OS X/i.test(navigator.userAgent)) {
                        document.documentElement.className += npF;
                    }
                } else if (ua.indexOf("Android") >= 0) {
                    fi.isAndroid = true;
                    var androidversion = parseFloat(ua.slice(ua.indexOf("Android") + 8));
                    if (androidversion < 3) {
                        document.documentElement.className += npF;
                    }
                } else if (ua.indexOf("BlackBerry") >= 0) {
                    fi.isBB = true;
                    if (ua.indexOf("Version/") >= 0) { // User Agent in BlackBerry 6 and BlackBerry 7
                    } else { // ***User Agent in BlackBerry Device Software 4.2 to 5.0
                        document.documentElement.className += npF;
                    }
                }
            } ());
        }
    }

    fi.utils.prepareMultiColumnSettings = function (count, columns) {

        var result = { lrsi: 0, eo: false, mc: false, c: columns, t: count };

        if (columns > 1) {
            result.mc = true;
            result.lrsi = count / columns;
            if (count % columns === 0) {
                result.lrsi = Math.max(0, result.lrsi - 1);
            }

            result.lrsi *= columns;
        }
        return result;
    };

    fi.utils.getMultiColumnClass = function (i, opt) {
        var r = '';
        if (opt) {
            if (opt.mc) {
                if (i < opt.c) {
                    r += ' first-row';
                }
                if (i >= opt.lrsi) {
                    r += ' last-row';
                }

                if (i % opt.c === 0) {
                    r += ' row-first-item';
                } else if (i % opt.c === opt.c - 1) {
                    r += ' row-last-item';
                }

                if (i === 0) r += ' first';
                if (i === opt.t - 1) r += ' last';
            }

            if (opt.eo) {
                r += i % 2 === 0 ? 'even' : 'odd';
            }
        }
        return r;
    };

} (FI));

(function (name, definition) {
    'use strict';

    if (typeof FI !== 'undefined') {
        FI[name] = definition();
    } else {
        this['$' + name] = definition();
    }
} ('script', function () {
    'use strict';
    var scripts = {},
        modules = {},
        doc = document,
        head = doc.getElementsByTagName('head')[0],
        validBase = /^https?:\/\//,
        domContentLoaded = 'DOMContentLoaded',
        readyState = 'readyState',
        addEventListener = 'addEventListener',
        onreadystatechange = 'onreadystatechange',
        scriptpath;
    function every(ar, fn) {
        var i, ii, r;
        for (i = 0, ii = ar.length; i < ii; i += 1) {
            r = fn(ar[i]);
            if (typeof r !== 'undefined' && !r) {
                return false;
            }
        }
        return true;
    }
    function each(ar, fn) {
        every(ar, function (el) {
            fn(el);
        });
    }

    if (!doc[readyState] && doc[addEventListener]) {
        doc[addEventListener](domContentLoaded, function fn() {
            doc.removeEventListener(domContentLoaded, fn, false);
            doc[readyState] = 'complete';
        }, false);
        doc[readyState] = 'loading';
    }

    function create(path, fn, name) {
        var el = doc.createElement('script'),
            loaded = false;

        name = name || path;
        el.onload = el.onerror = el[onreadystatechange] = function () {
            if ((el[readyState] && !(/^c|loade/.test(el[readyState]))) || loaded) {
                return;
            }
            el.onload = el[onreadystatechange] = null;
            loaded = true;
            scripts[name] = 2;
            if (fn) {
                fn();
            }
        };

        el.async = 1;
        el.src = path;
        head.insertBefore(el, head.firstChild);
    }

    function undefine(name, fn){
        if(modules.hasOwnProperty(name)){
            var m = modules[name];
            m.isDefined = false;
            if(typeof fn === "function"){
                fn();
            }
        }
    }

    function isDefined(name) {
        var result = false;
        if(modules.hasOwnProperty(name)) {
            result = modules[name].isDefined;
        }
        return result;
    }

    function define(name, fn) {
        if (modules.hasOwnProperty(name)) {
            var m = modules[name];
            if (!m.isDefined) {
                m.isDefined = true;
                if (typeof fn === "function") {
                    fn();
                }

                if (m.subscribers && m.subscribers.length) {
                    (function loopF(sb) {
                        if (m.subscribers.length) {
                            sb = m.subscribers[0];
                            if (typeof sb === "function") {
                                sb();
                            }

                            m.subscribers.shift();
                            loopF();
                        }
                    } ());
                }
            }
        } else {
            modules[name] = {
                isDefined: true
            };
            if (typeof fn === "function") {
                fn();
            }
        }
    }

    function loadAndDefineItem(path, name) {
        name = name || path;

        if (!modules.hasOwnProperty(name)) {
            modules[name] = {
                isDefined: false
            };
            if (!scripts.hasOwnProperty(name) && !scripts.hasOwnProperty(path)) {
                create(!validBase.test(path) && scriptpath ? scriptpath + path + '.js.aspx' : path, function () {
                    define(name);
                }, name);
            }
        }
    }
    function loadItem(path) {
        if (!scripts.hasOwnProperty(path)) {
            create(!validBase.test(path) && scriptpath ? scriptpath + path + '.js.aspx' : path, null, path);
        }
    }

    function $script() {
        return $script;
    }

    $script.DEBUG = function () {
        console.log(scripts);
        console.log(modules);
    };

    function ScriptDefine(dependencies) {
        this.dependencies = dependencies;
        this.queue = this.dependencies && this.dependencies.length ? this.dependencies.length : 0;
        this.definitions = [];
    }

    ScriptDefine.prototype = {
        setDependencies: function (dep) {
            this.dependencies = dep;
            this.queue = this.dependencies && this.dependencies.length ? this.dependencies.length : 0;
        },
        define: function (moduleName, definition) {
            if (this.queue) {
                this.definitions.push({
                    name: moduleName,
                    fn: definition
                });
            } else {
                define(moduleName, definition);
            }
            return this;
        },
        callback: function () {
            this.queue -= 1;
            if (this.queue === 0) {
                each(this.definitions, function (def) {
                    define(def.name, def.fn);
                });
            }
        }
    };

    // Sets the base path, so you don't need to include path in items
    $script.path = function (basePath) {
        scriptpath = basePath;
    };

    // Works same as requireAndDefine with more limitations (you can add one item only), but the path should be absolute path. this is useful to load item from CDN
    $script.get = function (path, name) {
        create(path, function () {
            define(name);
        }, name);
        return $script;
    };

    // Loads requested items. Please note that after this item you can only chain define. If you chain any other function, you will get nice javascript error.
    // USAGE: requires('jquery','mustache').define('pageme', function(){...})
    $script.requires = function () {
        var pendings = [],
            ret = new ScriptDefine();
        each(arguments, function (s) {
            if (modules.hasOwnProperty(s)) {
                var mo = modules[s];
                if (!mo.isDefined) {
                    pendings.push(s);
                    if (!mo.subscribers) {
                        mo.subscribers = [];
                    }
                    mo.subscribers.push(function () {
                        ret.callback();
                    });
                }
            } else {
                modules[s] = {
                    isDefined: false,
                    subscribers: [function () {
                        ret.callback();
                    }]
                };
                pendings.push(s);
                if (!scripts.hasOwnProperty(s)) {
                    // add script
                    loadItem(s);
                }
            }
        });

        ret.setDependencies(pendings);
        return ret;
    };

    // undefined a module. Please note undefine does not equal to unload :)
    // USAGE: undefine('MyModule', function() {});
    $script.undefine = function(moduleName, callback){
        undefine(moduleName, callback);
        return $script;
    };

    $script.isDefined = function(moduleName) {
        return isDefined(moduleName);
    };

    // loads an item if it is not loaded, and defines it as well. This is useful for items without dependencies. Especially third-party items like jQuery, JSON2, etc.
    // USAGE: requireAndDefine('jquery','json2',...)
    $script.requireAndDefine = function () {
        each(arguments, function (sc) {
            loadAndDefineItem(sc, sc);
        });
        return $script;
    };

    // defines a module. Use this when you don't have any dependencies
    // you can use this like: define('MyModule', function() {...})
    // if you omit the definition, system will just mark MyModule as defined
    $script.define = function (moduleName, definition) {
        define(moduleName, definition);
        return $script;
    };
    return $script();
}));