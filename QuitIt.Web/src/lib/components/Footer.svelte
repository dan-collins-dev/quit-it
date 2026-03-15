<script>
	import { resolve } from '$app/paths';
	import homeIconSrc from '$lib/assets/home-outline.svg';
	import triggerIconSrc from '$lib/assets/vulnerability-svgrepo-com.svg';
	import dashboardIconSrc from "$lib/assets/knowledge-graph-dashboard-svgrepo-com.svg"
</script>

<footer class="footer">
	<a href={resolve('/triggers')} class="logo-container nav-btn">
		<img class="logo" src={triggerIconSrc} alt="" />
		<p>Triggers</p>
	</a>

	<a href={resolve('/')} class="logo-container nav-btn">
		<img class="logo" src={homeIconSrc} alt="" />
		<p>Home</p>
	</a>

	<a href={resolve('/dashboard')} class="logo-container nav-btn">
		<img class="logo" src={dashboardIconSrc} alt="" />
		<p>Dashboard</p>
	</a>
</footer>

<style>
	a, a:visited {
		color: white;
		text-decoration: none;
	}

	a:active {
		color: #1fee14;
		outline-offset: 1rem;
	}

	@media (hover:hover) {
		a:hover {
			color: #1fee14;
		}
	}
</style>
