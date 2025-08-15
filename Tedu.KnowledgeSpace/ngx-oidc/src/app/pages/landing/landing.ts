import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FeaturesWidget } from './components/features-widget/features-widget';
import { FooterWidget } from './components/footer-widget/footer-widget';
import { HeroWidget } from './components/hero-widget/hero-widget';
import { HighlightsWidget } from './components/highlights-widget/highlights-widget';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { PricingWidget } from './components/pricing-widget/pricing-widget';
import { TopbarWidget } from './components/topbar-widget/topbar-widget';
import { DividerModule } from 'primeng/divider';
@Component({
  selector: 'app-landing',
  imports: [
    RouterModule,
    TopbarWidget,
    HeroWidget,
    FeaturesWidget,
    HighlightsWidget,
    PricingWidget,
    FooterWidget,
    RippleModule,
    StyleClassModule,
    ButtonModule,
    DividerModule,
  ],

  template: `
    <div class="bg-surface-0 dark:bg-surface-900">
      <div id="home" class="landing-wrapper overflow-hidden">
        <app-topbar-widget
          class="py-6 px-6 mx-0 md:mx-12 lg:mx-20 lg:px-20 flex items-center justify-between relative lg:static"
        />
        <app-hero-widget />
        <app-features-widget />
        <app-highlights-widget />
        <app-pricing-widget />
        <app-footer-widget />
      </div>
    </div>
  `,
  styles: ``,
})
export class Landing {}
