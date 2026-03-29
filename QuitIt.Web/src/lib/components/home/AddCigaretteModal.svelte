<script>
	import stopIcon from "$lib/assets/stop-palm-svgrepo-com.svg";

	async function addCigarette() {
		try {
			const res = await fetch("http://localhost:5150/api/logs", {
				method: "POST"
			});

			const data = await res.json();
			console.log(data);
			close();
		} catch (error) {
			console.error(error);
		}
	}

	let dialog;

	export function open() {
		dialog.style.display = "flex";
		dialog.showModal();
	}

	function close() {
		dialog.style.display = "none";
		dialog.close();
	}
</script>

<dialog bind:this={dialog}>

		<div class="logo-container">
			<img class="card-logo" src={stopIcon} alt="" srcset="" />
		</div>
		<h2>Do you really want to smoke that?</h2>

		<button class="confirm-btn" onclick={addCigarette}>Yes</button>
		<button class="cancel-btn" onclick={() => close()}>No</button>

</dialog>

<style>
	dialog {
		border: none;
		display: none;
		max-width: 80%;
		flex-direction: column;
		gap: 1rem;
		align-items: center;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
	}

	dialog::backdrop {
		background-color: rgba(0, 0, 0, 0.5);
	}

	.confirm-btn {
		background: linear-gradient(180deg, #ff0000, rgb(143, 0, 0));
		color: white;
	}

	.cancel-btn {
		background-color: green;
		color: white;
		background: linear-gradient(180deg, #6f8000, #003600);
	}

	button {
		font-size: large;
		border: none;
		padding: 1rem 2rem;
		border-radius: 5px;
		width: 100%;
	}

	h2 {
		text-align: center;
	}
</style>
