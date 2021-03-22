//Promise.all([
//    import('/web-components-cms-template/src/es/components/prototypes/Shadow.js').then(module => null), // preload the dependency
//    import('/web-components-cms-template/src/es/components/pages/General.js').then(module => ['p-general', module.default]),
//    import('/web-components-cms-template/src/es/components/organisms/Header.js').then(module => ['o-header', module.default]),
//    import('/web-components-cms-template/src/es/components/atoms/Logo.js').then(module => ['a-logo', module.default]),
//    import('/web-components-cms-template/src/es/components/molecules/Navigation.js').then(module => ['m-navigation', module.default]),
//    import('/web-components-cms-template/src/es/components/organisms/Body.js').then(module => ['o-body', module.default]),
//    import('/web-components-cms-template/src/es/components/organisms/Stage.js').then(module => ['o-stage', module.default]),
//    import('/web-components-cms-template/src/es/components/organisms/HighlightList.js').then(module => ['o-highlight-list', module.default]),
//    import('/web-components-cms-template/src/es/components/molecules/Highlight.js').then(module => ['m-highlight', module.default]),
//    import('/web-components-cms-template/src/es/components/organisms/Footer.js').then(module => ['o-footer', module.default]),
//    import('/web-components-cms-template/src/es/components/molecules/Flyer.js').then(module => ['m-flyer', module.default]),
//import('/web-components-cms-template/src/es/components/molecules/Teaser.js').then(module => ['m-teaser', module.default]),
//    import('/web-components-cms-template/src/es/components/organisms/TeaserWrapper.js').then(module => ['o-teaser-wrapper', module.default])
//]).then(elements => elements.forEach(element => {
//    // don't define already existing customElements
//    if (element && !customElements.get(element[0])) customElements.define(...element)
//}))


[
    ['p-general', General],
    ['o-header', Header],
    ['a-logo', Logo],
    ['m-navigation', Navigation],
    ['o-body', Body],
    ['o-stage', Stage],
    ['o-highlight-list', HighlightList],
    ['m-highlight', Highlight],
    ['o-footer', Footer],
    ['m-flyer', Flyer],
    ['m-teaser', Teaser],
    ['o-teaser-wrapper', TeaserWrapper],
].forEach(element => {
    // don't define already existing customElements
    if (element && !customElements.get(element[0])) customElements.define(...element)
})