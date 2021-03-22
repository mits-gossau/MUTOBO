/**
* First level controllers and organisms are loaded and defined here (loadChildComponents)
*/
Promise.all([
    // Controllers
    import('/web-components-cms-template/src/es/components/prototypes/Shadow.js').then(module => null), // preload the dependency
    import('/web-components-cms-template/src/es/components/pages/General.js').then(module => ['p-general', module.default]),
    import('/web-components-cms-template/src/es/components/organisms/Header.js').then(module => ['o-header', module.default]),
    import('/web-components-cms-template/src/es/components/atoms/Logo.js').then(module => ['a-logo', module.default]),
    import('/web-components-cms-template/src/es/components/molecules/Navigation.js').then(module => ['m-navigation', module.default]),
    import('/web-components-cms-template/src/es/components/organisms/Body.js').then(module => ['o-body', module.default]),
    import('/web-components-cms-template/src/es/components/organisms/Footer.js').then(module => ['o-footer', module.default]),
    import('/web-components-cms-template/src/es/components/molecules/Teaser.js').then(module => ['m-teaser', module.default]),
    import('/web-components-cms-template/src/es/components/organisms/TeaserWrapper.js').then(module => ['o-teaser-wrapper', module.default])
]).then(elements => elements.forEach(element => {
    // don't define already existing customElements
    if (element && !customElements.get(element[0])) customElements.define(...element)
}))

